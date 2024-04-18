﻿// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using BL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MaisonApple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class ProductImageController : ControllerBase
    {
        private readonly IProductImageManager _manager;
        public ProductImageController(IProductImageManager manager)
        {
            _manager = manager;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<ProductImageDto>>> Get()
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
        public async Task<ActionResult<ProductImageDto>> Get(int id)
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
        public async Task<ActionResult<int>> Add(ProductImageDto dto, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Aucun fichier n'a été téléchargé.");
                }

                // Convertir le fichier en tableau d'octets
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                var imageData = ms.ToArray();

                // Créer un objet ProductImageDto à partir des données du fichier
              dto.ImageData = imageData;

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
        public async Task<IActionResult> Update(ProductImageDto dto)
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
