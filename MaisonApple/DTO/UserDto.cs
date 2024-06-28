using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int points { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<CommandDto> Commands { get; set; }
    }
}
