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
    public interface IFavorisManager
    {
        Task AddToFavorite(string userId, int productId);
        Task<List<ProductDto>> GetFavoriteByUser(string userId);
        Task Delete(string userId, int productId);
    }
}
