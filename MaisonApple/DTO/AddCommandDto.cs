using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddCommandDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public Double Amount { get; set; }
        public string UserId { get; set; }
        public CommandStatusDto CommandStatus { get; set; } = CommandStatusDto.Loading;
        public List<AddOrderDto> Orders { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
