using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFIRST_FLUENT_API.Configurations
{
    public class Invoice_Detail_Configuration : IEntityTypeConfiguration<Invoice_Detail>
    {
        public void Configure(EntityTypeBuilder<Invoice_Detail> builder)
        {
            builder.ToTable("Invoice_Detail");
            builder.HasKey(e => new { e.Invoice_Id, e.Product_Detail_Id })
                    .HasName("PK_HoaDonCT");
            builder.Property(e => e.Quantity).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Price).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Unit_price_when_reduced).HasDefaultValueSql("((0))").IsRequired(true);
            builder.HasOne(d => d.Product_Detail_IdNavigation).WithMany(p => p.Invoice_Details).HasForeignKey(d => d.Product_Detail_Id);

            builder.HasOne(d => d.Invoice_Id_Navigation).WithMany(p => p.Invoice_Details).HasForeignKey(d => d.Invoice_Id);
        }
    }
}
