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
    public class Employee_Configuration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Employee_Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Employee_Name).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Middle_name).HasMaxLength(15);
            builder.Property(e => e.First_name).HasMaxLength(15);
            builder.Property(e => e.Last_name).HasMaxLength(15);
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Password).HasMaxLength(50).IsRequired(true).IsUnicode(false);
            builder.Property(e => e.Address).IsRequired();
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.Country).HasMaxLength(50);

            builder.Property(e => e.Phone_number).IsUnicode(false).HasMaxLength(15);

            builder.Property(e => e.Status).HasDefaultValueSql("((0))");

            builder.HasOne(d => d.StoreId_Navigation).WithMany(p => p.Employees).HasForeignKey(d => d.Store_Id);

            builder.HasOne(d => d.PositionId_Navigation).WithMany(p => p.Employees).HasForeignKey(d => d.Position_Id);

            builder.HasOne(d => d.Send_ReportId_Navigation).WithMany(p => p.InverseIdSend_ReportNavigations).HasForeignKey(d => d.Send_report_Id);
        }
    }
}
