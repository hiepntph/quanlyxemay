using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Motorcycle_Shop_Project.Models
{
    [DataContract]
    public class ProductDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Mã Sản Phẩm")]
        [StringLength(10, ErrorMessage = "Mã Sản Phẩm không được vượt quá 10 kí tự")]
        public string Product_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tên Sản Phẩm")]
        [StringLength(100, ErrorMessage = "Tên Sản Phẩm không được vượt quá 100 kí tự")]
        public string Product_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Product? ProductData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Product>? ProductList { get; set; }
    }
}
