// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int InitialPrice { get; set; }
        public int CurrentPrice { get; set; }
        public bool IsUsed { get; set; }
        public List<ProductImageDto>? Images { get; set; }
        public List<ProductColorDto>? Color { get; set; }
        public int CategoryId { get; set; }
    }
}
