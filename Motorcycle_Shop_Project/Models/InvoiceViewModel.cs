using Castle.MicroKernel.SubSystems.Conversion;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Motorcycle_Shop_Project.Models
{
    public class InvoiceViewModel
    {
        public Invoice? Invoice { get; set; }

        public Invoice_Detail? Invoice_Detail { get; set; }
    }

    public class Invoice
    {
        public Guid Id { get; set; }

        public Guid? Customer_Id { get; set; }

        public Guid? Employee_Id { get; set; }

        public string? Invoice_Id { get; set; }

        public DateTime? Create_Date { get; set; }

        public DateTime? Date_of_Payment { get; set; }

        public string? Customer_Name { get; set; }

        public string? Phone_Number { get; set; }

        public string? Address { get; set; }

        public decimal? Total_Money { get; set; }

        public decimal? Amound_Paid { get; set; }

        public int? Status { get; set; }
    }

        public class Invoice_Detail
    {
        
        public Guid Invoice_Id { get; set; }
        
        public Guid Product_Detail_Id { get; set; }
        
        public int? Quantity { get; set; }
        
        public decimal? Price { get; set; }
        
        public decimal Unit_price_when_reduced { get; set; }
        
        public decimal? Total_Money { get; set; }
    }
}
