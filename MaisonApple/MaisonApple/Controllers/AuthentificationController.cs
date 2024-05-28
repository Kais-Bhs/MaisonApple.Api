// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.IdentityModel.Tokens.Jwt;
using BL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MaisonApple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthentificationManager _manager;
        //private readonly ISecuri _tokenService;
        public AuthentificationController(IAuthentificationManager manager)
        {
            _manager = manager;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register(RegisterUserDto userDto)
        {
            try
            {
                var result = await _manager.Register(userDto);

                return CreatedAtAction(null, result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserDto userDto)
        {
            try
            {
                var token = await _manager.Login(userDto);

                if (string.IsNullOrEmpty(token)) // or check any other condition that indicates a failed login
                {
                    return Unauthorized("Invalid username or password");
                }

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                // _logger.LogError(ex, ex.Message);

                return StatusCode(500, $"An error occurred while processing your request: \n{ex.Message}");
            }
        }


    }

    public class CustomToken
    {
        public string? Username { get; set; }
        public string? Role { get; set; }

        // Constructor
        public CustomToken(JwtSecurityToken jwtToken)
        {
            // Extract the claims
            var claims = jwtToken.Claims;

            // Map the claims to the properties
            Username = claims.FirstOrDefault(x => x.Type == "username")?.Value;
            Role = claims.FirstOrDefault(x => x.Type == "role")?.Value;
        }
    }

}
