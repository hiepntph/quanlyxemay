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
    public class Position_Configuration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Position_Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Position_Name).IsUnicode(false).HasMaxLength(100).IsRequired(true);
        }
    }
}
