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
    public interface IPaymentManager
    {
        Task<int> Add(PaymentDto PaymentDto);

        Task Delete(int id);

        Task<IEnumerable<PaymentDto>> Get();

        Task<PaymentDto> Get(int id);

        Task<PaymentDto> Update(PaymentDto PaymentDto);
    }
}
