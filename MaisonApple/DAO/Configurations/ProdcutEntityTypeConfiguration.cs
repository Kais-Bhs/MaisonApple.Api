// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAO.Configurations
{
    internal class ProdcutEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name);
            builder.Property(x => x.QuantitéStock);
            builder.Property(x => x.Description);
            builder.Property(x => x.InitialPrice);
            builder.Property(x => x.CurrentPrice);
            builder.Property(x => x.IsUsed);


            builder.HasMany(x => x.Images)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

        }
    }
}
