// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int InitialPrice { get; set; }
        public int CurrentPrice { get; set; }
        public bool IsUsed { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductColorRelation> ProductColorRelations { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
