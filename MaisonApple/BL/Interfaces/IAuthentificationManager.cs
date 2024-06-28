// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DTO;

namespace BL.Interfaces
{
    public interface IAuthentificationManager
    {
        Task<string> Register(RegisterUserDto userDto);
        Task<string> Login(LoginUserDto userDto);
        Task VerifyEmail(string userId);
        Task<RegisterUserDto> Get(string userId);
        Task Update(UpdateUserDto updateUserDto);
        Task ResetMail(string email, string pswd);
        Task<IEnumerable<UserDto>> GetAllUser();
        Task DeleteUser(string userId);
    }
}
