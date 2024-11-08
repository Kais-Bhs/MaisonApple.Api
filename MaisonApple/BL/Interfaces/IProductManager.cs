﻿// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DTO;

namespace BL.Interfaces
{
    public interface IProductManager
    {
        Task<int> Add(ProductDto productDto);
        Task Delete(int id);

        Task<IEnumerable<ProductDto>> Get();

        Task<ProductDto> Get(int id);

        Task<ProductDto> Update(ProductDto productDto);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId);
        Task<IEnumerable<ProductColorDto>> GetALlColors();
    }
}
