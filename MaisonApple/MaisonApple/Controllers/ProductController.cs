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
    public partial class ProductController : ControllerBase
    {
        private readonly IProductManager _manager;
        private readonly IFavorisManager _favoris;
        public ProductController(IProductManager manager, IFavorisManager favoris)
        {
            _manager = manager;
            _favoris = favoris;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
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
        public async Task<ActionResult<ProductDto>> Get(int id)
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
        public async Task<ActionResult<int>> Add(ProductDto dto)
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
        public async Task<IActionResult> Update(ProductDto dto)
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

        [HttpGet("GetProductByCategoryId")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByCategoryId(int categoryId)
        {
            try
            {
                var result = await _manager.GetProductsByCategoryId(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet("GetALlColors")]
        public async Task<ActionResult<IEnumerable<ProductColorDto>>> GetALlColors()
        {
            try
            {
                var result = await _manager.GetALlColors();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpPost("AddToFavorite")]
        public async Task<IActionResult> AddToFavorite(string userId , int productId)
        {
            try
            {
                await _favoris.AddToFavorite(userId,productId);
                return CreatedAtAction(null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet("GetFavoriteByUser")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetFavoriteByUser(string userId)
        {
            try
            {
                var result = await _favoris.GetFavoriteByUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
