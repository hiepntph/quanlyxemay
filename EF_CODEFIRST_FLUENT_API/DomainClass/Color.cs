using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFIRST_FLUENT_API.DomainClass
{
    [DataContract]
    public class Color
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Mã Màu")]
        [StringLength(10, ErrorMessage = "Mã Màu không được vượt quá 10 kí tự")]
        public string Color_Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng Tên Màu")]
        [StringLength(100, ErrorMessage = "Mã Màu không được vượt quá 100 kí tự")]
        public string Color_Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Product_Detail>? Product_Details { get; set; }
    }
}
