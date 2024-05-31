namespace DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PaymentId { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
}
