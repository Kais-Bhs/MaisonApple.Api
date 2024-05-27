// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.IdentityModel.Tokens.Jwt;
using BL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<JwtSecurityTokenHandler>> Login(LoginUserDto userDto)
        {
            try
            {
                var result = await _manager.Login(userDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
