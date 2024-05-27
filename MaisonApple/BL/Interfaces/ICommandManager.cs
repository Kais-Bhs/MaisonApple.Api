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
using Entities;

namespace BL.Interfaces
{
    public interface ICommandManager
    {
        Task<int> Add(CommandDto PaymentDto);

        Task Delete(int id);

        Task<IEnumerable<CommandDto>> Get();

        Task<CommandDto> Get(int id);

        Task<CommandDto> Update(CommandDto PaymentDto);
    }
}
