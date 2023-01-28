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
    public class Event_Configuration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Event_Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Event_Name).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Discount_Unit).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Discount_Rate).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Status).HasDefaultValueSql("((0))");
        }
    }
}
