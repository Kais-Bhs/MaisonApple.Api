// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BL.Interfaces;
using DTO;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BL.Managers
{
    public class AuthentificationManager : IAuthentificationManager
    {
        private readonly UserManager<User> _userStore;
        public readonly JWTConfiguration _JWTConfiguration;
        private readonly IMapper _mapper;
        public AuthentificationManager(UserManager<User> userStore, JWTConfiguration JWTConfiguration, IMapper mapper)
        {
            _userStore = userStore;
            _JWTConfiguration = JWTConfiguration;
            _mapper = mapper;
        }

        public async Task<string> Register(RegisterUserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                IdentityResult result = await _userStore.CreateAsync(user, userDto.Password);
                IdentityResult resultRole = await _userStore.AddToRoleAsync(user, userDto.Role);

                return user.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task<string> Login(LoginUserDto userDto)
        {
            try
            {
                User? userFromDB = await _userStore.FindByNameAsync(userDto.UserName);

                if (userFromDB != null)
                {
                    bool found = await _userStore.CheckPasswordAsync(userFromDB, userDto.Password);

                    if (found)
                    {
                        List<Claim> myclaim = new List<Claim>();
                        myclaim.Add(new Claim(ClaimTypes.Name, userFromDB.UserName));
                        myclaim.Add(new Claim(ClaimTypes.NameIdentifier, userFromDB.Id));
                        myclaim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); //jti ==> Token id

                        var roles = await _userStore.GetRolesAsync(userFromDB);
                        foreach (var role in roles)
                        {
                            myclaim.Add(new Claim(ClaimTypes.Role, role));
                        }

                        var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTConfiguration.SecritKey)); //"ssssssssssssssssssssssssssssssssssssssssssssssssssssss"
                        var signingCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(myclaim),
                            Expires = DateTime.Now.AddHours(1),
                            SigningCredentials = signingCredentials,
                            Issuer = _JWTConfiguration.ValidIss,
                            Audience = _JWTConfiguration.ValidAud
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        return tokenHandler.WriteToken(token);
                    }
                    else
                    {
                        throw new Exception("Incorrect Mot De Passe");
                    }
                }
                else
                {
                    throw new Exception("Incorrect UserName");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}