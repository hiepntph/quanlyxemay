using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Motorcycle_Shop_Project.Models
{
    [DataContract]
    public class CategoryDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập mã dòng Sản phẩm")]
        [StringLength(20, ErrorMessage = "Mã dòng Sản phẩm không được vượt quá 20 kí tự")]
        public string Category_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tên dòng Sản phẩm")]
        [StringLength(30, ErrorMessage = "Tên dòng Sản phẩm không được vượt quá 30 kí tự")]
        public string Category_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Category? CategoryData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Category>? Product_LineList { get; set; }
    }
}
