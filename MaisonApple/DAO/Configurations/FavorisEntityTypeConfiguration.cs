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
    internal class FavorisEntityTypeConfiguration : IEntityTypeConfiguration<Favoris>
    {
        public void Configure(EntityTypeBuilder<Favoris> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();


            builder.HasOne(x => x.User)
                .WithMany(x => x.Favoris)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Product)
              .WithMany(x => x.Favoris)
              .HasForeignKey(x => x.ProductId);

        }
    }
}
