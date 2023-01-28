using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Shop_Project.Models
{
    [DataContract]
    public class WarrantyDTO
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
        public DateTime Start_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime? End_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [StringLength(50, ErrorMessage = "Biển số xe không được vượt quá 50 kí tự")]
        public string? License_Plate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int? Status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Tên Khách Hàng không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên Khách Hàng không được vượt quá 100 kí tự")]
        public string? Customer_Name { get; set; }
        public string? Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 kí tự")]
        public string Phone_Number { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Address { get; set; }
        public Warranty? WarrantyData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Keyword { get; set; }
        public List<Warranty>? WarrantyList { get; set; }
    }
}
