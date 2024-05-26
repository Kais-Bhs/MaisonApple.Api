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
    internal class PaymentEntityTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Date);
            builder.Property(x => x.Method);
            builder.Property(x => x.Amount);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Payment)
                .HasForeignKey(x => x.PaymentId);

            builder.HasOne(x => x.User)
                .WithMany(u => u.payments)
                .HasForeignKey(x => x.UserId);
        }
    }
}
