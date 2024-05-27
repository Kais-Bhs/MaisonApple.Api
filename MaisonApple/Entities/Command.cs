using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Command
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public Double Amount { get; set; }
        public CommandStatus CommandStatus { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
