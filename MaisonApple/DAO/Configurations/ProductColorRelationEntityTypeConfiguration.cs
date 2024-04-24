using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Configurations
{
    internal class ProductColorRelationEntityTypeConfiguration : IEntityTypeConfiguration<ProductColorRelation>
    {
        public void Configure(EntityTypeBuilder<ProductColorRelation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(x => new { x.ProductId, x.ColorId })
                .IsUnique(true);

            builder.HasOne(x => x.ProductColor)
              .WithMany(x => x.ProductColorRelations)
              .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Product)
              .WithMany(x => x.ProductColorRelations)
              .HasForeignKey(x => x.ProductId);

        }
    }
}
