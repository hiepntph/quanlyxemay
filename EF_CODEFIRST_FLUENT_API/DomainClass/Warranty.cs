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
    public class Warranty
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid? Customer_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid? Employee_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid? Product_Detail_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime Start_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime End_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [StringLength(50, ErrorMessage = "Biển số xe không được vượt quá 50 kí tự")]
        public string? License_Plate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int? Status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Product_Detail? Product_Detail_Id_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Employee? EmployeeId_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Customer? CustomerId_Navigation { get; set; }
    }
}
