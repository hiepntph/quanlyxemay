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
    public class Save_Product_Detail_Configuration : IEntityTypeConfiguration<Save_Product_Detail>
    {
        public void Configure(EntityTypeBuilder<Save_Product_Detail> builder)
        {
            builder.ToTable("Save_Product_Detail");
            builder.HasKey(e => new { e.Save_Product_Id, e.Product_Detail_Id });

            builder.Property(e => e.Unit_Price).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Unit_price_when_reduced).HasDefaultValueSql("((0))").IsRequired(true);

            builder.HasOne(d => d.Product_Detail_Id_Navigation).WithMany(p => p.Save_Product_Details).HasForeignKey(d => d.Product_Detail_Id);

            builder.HasOne(d => d.Save_Product_Id_Navigation).WithMany(p => p.Save_Product_Details).HasForeignKey(d => d.Save_Product_Id);
        }
    }
}
