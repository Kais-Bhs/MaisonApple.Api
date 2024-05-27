namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PaymentId { get; set; }

        public Command Payment { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
