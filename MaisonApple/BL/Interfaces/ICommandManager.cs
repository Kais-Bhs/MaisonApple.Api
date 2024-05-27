// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DTO;

namespace BL.Interfaces
{
    public interface ICommandManager
    {
        Task<int> Add(CommandDto PaymentDto);

        Task Delete(int id);

        Task<IEnumerable<CommandDto>> Get();

        Task<CommandDto> Get(int id);

        Task<CommandDto> Update(CommandDto PaymentDto);
        Task AcceptCommmand(int commandId);

        Task RejectCommmand(int commandId);
        Task<IEnumerable<CommandDto>> GetCommandsByUser(string userId);
    }
}
