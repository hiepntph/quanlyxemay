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
    public class Producer_Configuration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producer");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Producer_Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Producer_Name).HasMaxLength(100).IsRequired(true);
        }
    }
}
