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
    public partial class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _manager;
        public PaymentController(IPaymentManager manager)
        {
            _manager = manager;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> Get()
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
        public async Task<ActionResult<PaymentDto>> Get(int id)
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
        public async Task<ActionResult<int>> Add(PaymentDto dto)
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
        public async Task<IActionResult> Update(PaymentDto dto)
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
    }
}
