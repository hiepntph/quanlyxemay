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
    public class Ware_House_Detail_Configuration : IEntityTypeConfiguration<Ware_House_Detail>
    {
        public void Configure(EntityTypeBuilder<Ware_House_Detail> builder)
        {
            builder.ToTable("Ware_House_Detail");
            builder.HasKey(e => new { e.Ware_House_Id, e.Product_Detail_Id });

            builder.Property(e => e.Quantity_entered).HasDefaultValueSql("((0))");
            builder.Property(e => e.Quantity_in_stock).HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Product_Detail_Id_Navigation).WithMany(p => p.Ware_House_Details).HasForeignKey(d => d.Product_Detail_Id);

            builder.HasOne(d => d.Ware_HouseId_Navigation).WithMany(p => p.Ware_House_Details).HasForeignKey(d => d.Ware_House_Id);
            
        }
    }
}
