using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
