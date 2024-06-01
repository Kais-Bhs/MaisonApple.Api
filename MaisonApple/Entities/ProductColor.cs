using System.Collections.Generic;

namespace Entities
{
    public class ProductColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
        public ICollection<ProductColorRelation> ProductColorRelations { get; set; }
    }
}
