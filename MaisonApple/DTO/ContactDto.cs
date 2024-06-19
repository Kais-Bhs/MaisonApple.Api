using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContactDto
    {
        public string Body { get; set; }
        public List<byte[]>? pictures { get; set; }
        public string UserTel { get; set; }
        public string UserEmail { get; set;}
        public ContactTypeDto ContactType { get; set; }
    }
}
