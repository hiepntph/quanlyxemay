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
    public class Invoice_Configuration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Invoice_Id).IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Phone_Number).IsUnicode(false);
            builder.Property(e => e.Status).HasDefaultValueSql("((0))");
            builder.Property(e => e.Customer_Name).HasMaxLength(45).IsRequired(true);
            builder.Property(e => e.Address).IsRequired(true);
            builder.Property(e => e.Phone_Number).HasMaxLength(15).IsRequired(true);
            builder.Property(e => e.Total_Money).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Amound_Paid).HasDefaultValueSql("((0))").IsRequired(true);
            builder.Property(e => e.Status).HasDefaultValueSql("((0))");
            builder.HasOne(d => d.CustomerId_Navigation).WithMany(p => p.Invoices).HasForeignKey(d => d.Customer_Id);
            builder.HasOne(d => d.EmployeeId_Navigation).WithMany(p => p.Invoices).HasForeignKey(d => d.Employee_Id);
        }
    }
}
