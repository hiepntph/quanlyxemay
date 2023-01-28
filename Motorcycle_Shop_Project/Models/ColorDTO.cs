using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Motorcycle_Shop_Project.Models
{
    public class ColorDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mã Màu")]
        [StringLength(20, ErrorMessage = "Mã Màu không được vượt quá 20 kí tự")]
        [DataMember(EmitDefaultValue = false)]
        public string Id_Color { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên Màu")]
        [StringLength(30, ErrorMessage = "Tên Màu không được vượt quá 30 kí tự")]
        [DataMember(EmitDefaultValue = false)]
        public string Color_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Color? ColorData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Color>? ColorList { get; set; }
    }
}
