// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
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

        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string userId)
        {
            try
            {
                await _manager.VerifyEmail(userId);
                
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while processing your request: \n{ex.Message}");
            }
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<RegisterUserDto>> Get(string id)
        {
            try
            {
                var result = await _manager.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            try
            {
                await _manager.Update(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpPut("ResetMail")]
        public async Task<IActionResult> ResetMail(string email, string pswd)
        {
            try
            {
                await _manager.ResetMail(email,pswd);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUser()
        {
            try
            {
                var result = await _manager.GetAllUser();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                await _manager.DeleteUser(userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
