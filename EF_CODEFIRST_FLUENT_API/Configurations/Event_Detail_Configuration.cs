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
    public class Event_Detail_Configuration : IEntityTypeConfiguration<Event_Detail>
    {
        public void Configure(EntityTypeBuilder<Event_Detail> builder)
        {
            builder.ToTable("Event_Detail");
            builder.HasKey(e => new { e.Event_Id, e.Product_Detail_Id });

            builder.Property(e => e.Status).HasDefaultValueSql("((0))").IsRequired(true);

            builder.HasOne(d => d.Product_Detail_Id_Navigation).WithMany(p => p.Event_Details).HasForeignKey(d => d.Product_Detail_Id);

            builder.HasOne(d => d.Event_Id_Navigation).WithMany(p => p.Event_Details).HasForeignKey(d => d.Event_Id);
        }
    }
}
