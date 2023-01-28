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
    public class Store_Configuration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Store_Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Store_Name).IsUnicode(false).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Address).IsRequired(true);
            builder.Property(e => e.Status).HasDefaultValueSql("((0))");
        }
    }
}
