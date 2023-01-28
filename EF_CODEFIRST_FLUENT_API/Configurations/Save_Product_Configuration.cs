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
    public class Save_Product_Configuration : IEntityTypeConfiguration<Save_Product>
    {
        public void Configure(EntityTypeBuilder<Save_Product> builder)
        {
            builder.ToTable("Save_Product");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Save_Product_Id).IsRequired(true).IsUnicode(false).HasMaxLength(10);
            builder.HasOne(d => d.Customer_Id_Navigation).WithMany(p => p.Save_Products).HasForeignKey(d => d.Customer_Id);
        }
    }
}
