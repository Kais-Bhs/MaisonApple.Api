// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DTO;

namespace BL.Interfaces
{
    public interface IProductImageManager
    {
        Task<int> Add(ProductImageDto productImageDto);
        Task Delete(int id);

        Task<IEnumerable<ProductImageDto>> Get();

        Task<ProductImageDto> Get(int id);

        Task<ProductImageDto> Update(ProductImageDto productImageDto);
        Task<IEnumerable<ProductImageDto>> GetProductImagesByProductId(int productId);
    }
}
