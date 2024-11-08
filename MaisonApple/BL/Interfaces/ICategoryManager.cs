﻿// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DTO;

namespace BL.Interfaces
{
    public interface ICategoryManager
    {
        Task<int> Add(CategoryDto categoryDto);
        Task Delete(int id);

        Task<IEnumerable<CategoryDto>> Get();

        Task<CategoryDto> Get(int id);

        Task<CategoryDto> Update(CategoryDto categoryDto);
    }
}
