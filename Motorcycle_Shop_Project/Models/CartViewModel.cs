using Castle.MicroKernel.SubSystems.Conversion;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Motorcycle_Shop_Project.Models
{
    public class CartViewModel
    {
        public Save_Product Save_Product { get; set; }

        public Save_Product_Detail Save_Product_Detail { get; set; }
    }

    public class Save_Product
    {
        public Guid Id { get; set; }
        public Guid Customer_Id { get; set; }
        public string Save_Product_Id { get; set; }
        public DateTime Save_Date { get; set; }
        public string? Description { get; set; }
    }

    public class Save_Product_Detail
    {
        public Guid Save_Product_Id { get; set; }
        public Guid Product_Detail_Id { get; set; }
        public decimal Unit_Price { get; set; }
        public decimal Unit_price_when_reduced { get; set; }
    }
}
