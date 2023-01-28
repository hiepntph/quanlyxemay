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
    public class Ware_House_Configuration : IEntityTypeConfiguration<Ware_House>
    {
        public void Configure(EntityTypeBuilder<Ware_House> builder)
        {
            builder.ToTable("Ware_House");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Ware_House_Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Ware_House_Name).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Address).IsRequired(true);
            builder.Property(e => e.Status).HasDefaultValueSql("((0))");
        }
    }
}
