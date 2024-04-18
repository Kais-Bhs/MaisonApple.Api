// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.Reflection.Metadata;
using DAO.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class MaisonAppleContext : DbContext
    {
        public MaisonAppleContext(DbContextOptions<MaisonAppleContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProdcutEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
            new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
            new ProductImageEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductImage>());
        }
    }
}
