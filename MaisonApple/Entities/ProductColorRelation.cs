namespace Entities
{
    public class ProductColorRelation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public ProductColor? ProductColor { get; set; }
        public Product? Product { get; set; }
    }
}
