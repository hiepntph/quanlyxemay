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
    public class Product_Detail_Configuration : IEntityTypeConfiguration<Product_Detail>
    {
        public void Configure(EntityTypeBuilder<Product_Detail> builder)
        {
            builder.ToTable("Product_Detail");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Price).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Quantity_in_stock).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Import_Price).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Month_Warranty).HasDefaultValueSql("((0))").IsRequired(true);


            builder.HasOne(d => d.CategoryId_Nagation).WithMany(p => p.Product_Details).HasForeignKey(d => d.Category_Id);

            builder.HasOne(d => d.ColorId_Navigation).WithMany(p => p.Product_Details).HasForeignKey(d => d.Color_Id);

            builder.HasOne(d => d.ProducerId_Navigation).WithMany(p => p.Product_Details).HasForeignKey(d => d.Producer_Id);

            builder.HasOne(d => d.ProductId_Navigation).WithMany(p => p.Product_Details).HasForeignKey(d => d.Product_Id);
        }
    }
}
