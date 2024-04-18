// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
