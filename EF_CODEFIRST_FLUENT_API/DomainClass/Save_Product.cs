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
    public class Save_Product
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Customer_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Save_Product_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime Save_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Customer? Customer_Id_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Save_Product_Detail>? Save_Product_Details { get; set; }
    }
}
