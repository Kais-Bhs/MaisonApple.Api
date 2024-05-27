// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace DTO
{
    public class CommandDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public Double Amount { get; set; }
        public Guid UserId { get; set; }
        public CommandStatusDto CommandStatus { get; set; } = CommandStatusDto.Loading;
        public List<OrderDto> Orders { get; set; }
    }
}
