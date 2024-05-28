// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.IdentityModel.Tokens.Jwt;
using DTO;

namespace BL.Interfaces
{
    public interface IAuthentificationManager
    {
        Task<string> Register(RegisterUserDto userDto);
        Task<string> Login(LoginUserDto userDto);
    }
}
