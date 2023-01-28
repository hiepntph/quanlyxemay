using Castle.MicroKernel.SubSystems.Conversion;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Motorcycle_Shop_Project.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public Category Category { get; set; }

        public Color Color { get; set; }

        public Producer Producer { get; set; }

        public Product_Detail Product_Detail { get; set; }
        public Event Event { get; set; }

        public Event_Detail Event_Detail { get; set; }
    }

}
