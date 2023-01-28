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
    public class Event
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Mã Sự Kiện")]
        [StringLength(10, ErrorMessage = "Mã Sự kiện không được vượt quá 10 kí tự")]
        public string Event_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập tên Sự Kiện")]
        [StringLength(100, ErrorMessage = "Tên Sự kiện không được vượt quá 100 kí tự")]
        public string Event_Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int Discount_Unit { get; set; }  // 0: theo % 1: theo VNĐ

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Mức giảm giá")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải là số")]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? Discount_Rate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "datetime")]
        public DateTime? Start_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "datetime")]
        public DateTime? End_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Image { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Event_Detail>? Event_Details { get; set; }
    }
}
