// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace DTO
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageUrl { get; set; }
    }
}
