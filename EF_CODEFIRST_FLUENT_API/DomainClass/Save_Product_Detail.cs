using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFIRST_FLUENT_API.DomainClass
{
    [DataContract]
    public class Save_Product_Detail
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid Save_Product_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Product_Detail_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal Unit_Price { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal Unit_price_when_reduced { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Product_Detail? Product_Detail_Id_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Save_Product? Save_Product_Id_Navigation { get; set; }
    }
}
