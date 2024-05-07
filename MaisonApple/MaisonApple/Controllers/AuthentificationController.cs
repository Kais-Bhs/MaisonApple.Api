// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace MaisonApple.Controllers
{
    public class AuthentificationController : ControllerBase
    {
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        //private readonly ISecuri _tokenService;
        public AuthentificationController(IUserStore<IdentityUser> userStore, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _userStore = userStore;
            _passwordHasher = passwordHasher;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = new IdentityUser
            {
                UserName = email,
                Email = email
            };
            var psw = _passwordHasher.HashPassword(user, password);
            var result = await _userStore.CreateAsync(user, CancellationToken.None);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
        //[HttpPost("Login")]
        //public async Task<IActionResult> Login(string email, string password)
        //{
        //    var user = await _userStore.FindByEmailAsync(email);

        //    if (user == null || !_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password).Equals(PasswordVerificationResult.Success))
        //    {
        //        return Unauthorized();
        //    }

        //    var token = await _tokenService.GenerateAccessTokenAsync(user);

        //    return Ok(new { token });
        //}

    }
}
