using System;
using System.Collections.Generic;

namespace Entities
{
    public class Command
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public string Method { get; set; }
        public Double Amount { get; set; }
        public CommandStatus CommandStatus { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
