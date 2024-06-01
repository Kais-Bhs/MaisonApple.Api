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
        private readonly IMailService _mailService;
        public AuthentificationManager(UserManager<User> userStore, JWTConfiguration JWTConfiguration, IMapper mapper, IMailService mailService)
        {
            _userStore = userStore;
            _JWTConfiguration = JWTConfiguration;
            _mapper = mapper;
            _mailService = mailService;
        }
        public async Task<RegisterUserDto> Get(string userId)
        {
            try
            {
                var user = await _userStore.FindByIdAsync(userId);

                return _mapper.Map<RegisterUserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task Update(UpdateUserDto updateUserDto)
        {
            try
            {
                var user = await _userStore.FindByIdAsync(updateUserDto.Id);

                if (_userStore.CheckPasswordAsync(user, updateUserDto.OldPassword).Result)
                {
                    var passwordValidator = new PasswordValidator<User>();
                    var result = await passwordValidator.ValidateAsync(_userStore, user, updateUserDto.NewPassword);

                    var hashedPassword = _userStore.PasswordHasher.HashPassword(user, updateUserDto.NewPassword);

                    user.PasswordHash = hashedPassword;
                    user.UserName = updateUserDto.UserName;
                    user.PhoneNumber = updateUserDto.PhoneNumber;
                    user.Email = updateUserDto.Email;

                    await _userStore.UpdateAsync(user);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<string> Register(RegisterUserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                IdentityResult result = await _userStore.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    string verificationLink = $"https://localhost:7028/api/Authentification/VerifyEmail?userId={user.Id}";

                    await SendVerificationEmail(user.Email, verificationLink);

                    IdentityResult resultRole = await _userStore.AddToRoleAsync(user, userDto.Role);
                }

                return user.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task VerifyEmail(string userId)
        {
            try
            {
                if (userId != null)
                {
                    var user = await _userStore.FindByIdAsync(userId);

                    user.EmailConfirmed = true;
                    await _userStore.UpdateAsync(user);


                }
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
        private async Task SendVerificationEmail(string email, string verificationLink)
        {
            string subject = "Confirmez votre adresse e-mail pour profiter pleinement de MaisonApple";

            string body = $"Bonjour,\r\n\r\n" +
                $"Merci de vous être inscrit sur MaisonApple, la boutique en ligne dédiée aux produits Apple. " +
                $"Pour finaliser votre inscription et profiter pleinement de tous nos services, nous avons besoin de vérifier votre adresse e-mail.\r\n\r\n" +
                $"Cliquez sur le bouton ci-dessous pour confirmer votre adresse e-mail :\r\n\r\n[Vérifier mon adresse e-mail] {verificationLink}\r\n\r\n" +
                $"En tant que client vérifié, vous pourrez :\r\n\r\nSuivre vos commandes en temps réel\r\nBénéficier de nos offres promotionnelles exclusives\r\n" +
                $"Accéder à notre service après-vente en ligne\r\nSi vous ne parvenez pas à cliquer sur le bouton, copiez et collez le lien suivant dans votre navigateur : {verificationLink}\r\n\r\n" +
                $"Si vous n'avez pas créé de compte sur MaisonApple, veuillez ignorer ce message.\r\n\r\nMerci de votre confiance et à bientôt sur MaisonApple.\r\n\r\n" +
                $"L'équipe MaisonApple";

            await _mailService.SendEmail(email, subject, body, null, null);
        }
    }
}