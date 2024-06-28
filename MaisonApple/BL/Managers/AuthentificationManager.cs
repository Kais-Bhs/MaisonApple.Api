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
using DAL;
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
        private readonly IUnitOfWork _unitOfWork;
        public AuthentificationManager(UserManager<User> userStore, JWTConfiguration JWTConfiguration, IMapper mapper, IMailService mailService, IUnitOfWork unitOfWork)
        {
            _userStore = userStore;
            _JWTConfiguration = JWTConfiguration;
            _mapper = mapper;
            _mailService = mailService;
            _unitOfWork = unitOfWork;
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
                    user.PhoneNumber = updateUserDto.PhoneNumber.ToString();
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
                        if(userFromDB.EmailConfirmed)
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
                        }else
                        {
                            throw new Exception("Compte n'est pas verifié");
                        }

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
        public async Task ResetMail(string email,string pswd)
        {
            try
            {
                var user = await _userStore.FindByEmailAsync(email);

                if(user != null)
                {
                    var passwordValidator = new PasswordValidator<User>();
                    var result = await passwordValidator.ValidateAsync(_userStore, user, pswd);

                    var hashedPassword = _userStore.PasswordHasher.HashPassword(user, pswd);

                    user.PasswordHash = hashedPassword;

                    await _userStore.UpdateAsync(user);
                }else { throw new Exception(); }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<UserDto>> GetAllUser()
        {
            try
            {      
                var users = _userStore.Users.ToList();
                var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
                foreach (var user in userDtos)
                {
                    var commands = await _unitOfWork.RepoCommand.Query(n => n.UserId == user.Id);
                    var commandDtos = _mapper.Map<IEnumerable<CommandDto>>(commands);
                    foreach (var commandDto in commandDtos)
                    {
                        var orders = await _unitOfWork.RepoOrder.GetOrdersByCommanId(commandDto.Id);
                        commandDto.Orders = _mapper.Map<List<OrderDto>>(orders);
                    }
                    user.Commands = commandDtos.ToList();
                }

                return userDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteUser(string userId)
        {
            try
            {
                var user = await _userStore.FindByIdAsync(userId);
                await _userStore.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private async Task SendVerificationEmail(string email, string verificationLink)
        {
            string subject = "Confirmez votre adresse e-mail pour profiter pleinement de MaisonApple";

            string body = $@"
<!DOCTYPE html>
<html lang='fr'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        body {{
            font-family: Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            margin: 0;
            padding: 0;
            background-color: #f7f7f7;
        }}
        .container {{
            width: 80%;
            max-width: 600px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }}
        .button {{
            display: inline-block;
            padding: 10px 20px;
            margin: 20px 0;
            color: #fff;
            background-color: #007BFF;
            text-decoration: none;
            border-radius: 5px;
        }}
        .footer {{
            margin-top: 20px;
            font-size: 0.9em;
            color: #777;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <p>Bonjour,</p>
        <p>Merci de vous être inscrit sur MaisonApple, la boutique en ligne dédiée aux produits Apple. Pour finaliser votre inscription et profiter pleinement de tous nos services, nous avons besoin de vérifier votre adresse e-mail.</p>
        <p>Cliquez sur le bouton ci-dessous pour confirmer votre adresse e-mail :</p>
        <p><a href='{verificationLink}' class='button'>Vérifier mon adresse e-mail</a></p>
        <p>En tant que client vérifié, vous pourrez :</p>
        <ul>
            <li>Suivre vos commandes en temps réel</li>
            <li>Bénéficier de nos offres promotionnelles exclusives</li>
            <li>Accéder à notre service après-vente en ligne</li>
        </ul>
        <p>Si vous ne parvenez pas à cliquer sur le bouton, copiez et collez le lien suivant dans votre navigateur : <a href='{verificationLink}'>{verificationLink}</a></p>
        <p>Si vous n'avez pas créé de compte sur MaisonApple, veuillez ignorer ce message.</p>
        <p>Merci de votre confiance et à bientôt sur MaisonApple.</p>
        <p class='footer'>L'équipe MaisonApple</p>
    </div>
</body>
</html>";


            await _mailService.SendEmail(email, subject, body, null, null);
        }
    }
}