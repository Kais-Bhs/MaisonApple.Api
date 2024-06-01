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
    public partial class CommandController : ControllerBase
    {
        private readonly ICommandManager _manager;
        public CommandController(ICommandManager manager)
        {
            _manager = manager;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<CommandDto>>> Get()
        {
            try
            {
                var result = await _manager.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<CommandDto>> Get(int id)
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

        [HttpPost("Add")]
        public async Task<ActionResult<int>> Add(AddCommandDto dto)
        {
            try
            {
                var result = await _manager.Add(dto);
                return CreatedAtAction(null, result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _manager.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CommandDto dto)
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
        [HttpPut("AcceptCommmand")]
        public async Task<IActionResult> AcceptCommmand(AddCommandDto commandDto)
        {
            try
            {
                await _manager.AcceptCommmand(commandDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpPut("RejectCommmand")]
        public async Task<IActionResult> RejectCommmand(int commandId)
        {
            try
            {
                await _manager.RejectCommmand(commandId);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet("GetCommandsByUser")]
        public async Task<ActionResult<IEnumerable<CommandDto>>> GetCommandsByUser(string userId)
        {
            try
            {
                var result = await _manager.GetCommandsByUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
