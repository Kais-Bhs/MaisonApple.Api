namespace DTO
{
    public class AddOrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CommandId { get; set; }
        public int ProductId { get; set; }
    }
}
