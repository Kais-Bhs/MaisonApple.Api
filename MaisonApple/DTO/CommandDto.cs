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
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public Double Amount { get; set; }
        public string UserId { get; set; }
        public RegisterUserDto? User { get; set; }
        public CommandStatusDto CommandStatus { get; set; } = CommandStatusDto.Loading;
        public List<OrderDto> Orders { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
