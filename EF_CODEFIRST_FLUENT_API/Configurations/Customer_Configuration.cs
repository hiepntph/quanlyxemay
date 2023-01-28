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
    public class Customer_Configuration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Customer_Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Customer_Name).HasMaxLength(45);
            builder.Property(e => e.Middle_name).HasMaxLength(15);
            builder.Property(e => e.First_name).HasMaxLength(15);
            builder.Property(e => e.Last_name).HasMaxLength(15);
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Password).HasMaxLength(50).IsRequired(true).IsUnicode(false);
            builder.Property(e => e.Address).IsRequired();
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.Country).HasMaxLength(50);
            builder.Property(e => e.Phone_number).IsUnicode(false).HasMaxLength(15).IsRequired(true);
        }
    }
}
