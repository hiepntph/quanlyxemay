using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.EntityFrameworkCore;
using EF_CODEFIRST_FLUENT_API.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Context
{
    public partial class Connection_DBContext : DbContext
    {
        /// <summary>
        /// Cấu hình CSDL thông qua đường dẫn,sẽ tạo CSDL mới nếu CSDL(Catalog = ?) đó chưa tồn tại
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-2GTIBL55\SQLEXPRESS;Initial Catalog=DB_ASM_CSHARP5_2;Integrated Security=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Event_Detail> Event_Details { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        //3. Khai báo các bảng DBSet sẽ được ánh xạ sang CSDL
        public DbSet<Product_Detail> Product_Details { get; set; }
        public DbSet<Save_Product> Save_Products { get; set; }
        public DbSet<Save_Product_Detail> Save_Product_Details { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoice_Detail> Invoice_Details { get; set; }
        public DbSet<Ware_House> Ware_Houses { get; set; }
        public DbSet<Ware_House_Detail> Ware_House_Details { get; set; }
        public DbSet<Warranty> Warranties { get; set; }

        /// <summary>
        /// Tiến hành xây dựng CSDL
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Category_Configuration());
            modelBuilder.ApplyConfiguration(new Color_Configuration());
            modelBuilder.ApplyConfiguration(new Customer_Configuration());
            modelBuilder.ApplyConfiguration(new Employee_Configuration());
            modelBuilder.ApplyConfiguration(new Event_Configuration());
            modelBuilder.ApplyConfiguration(new Event_Detail_Configuration());
            modelBuilder.ApplyConfiguration(new Invoice_Detail_Configuration());
            modelBuilder.ApplyConfiguration(new Invoice_Configuration());
            modelBuilder.ApplyConfiguration(new Position_Configuration());
            modelBuilder.ApplyConfiguration(new Producer_Configuration());
            modelBuilder.ApplyConfiguration(new Product_Configuration());
            modelBuilder.ApplyConfiguration(new Product_Detail_Configuration());
            modelBuilder.ApplyConfiguration(new Save_Product_Detail_Configuration());
            modelBuilder.ApplyConfiguration(new Save_Product_Configuration());
            modelBuilder.ApplyConfiguration(new Store_Configuration());
            modelBuilder.ApplyConfiguration(new Ware_House_Detail_Configuration());
            modelBuilder.ApplyConfiguration(new Ware_House_Configuration());
            modelBuilder.ApplyConfiguration(new Warranty_Configuration());
        }
    }
}
