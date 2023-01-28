using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Motorcycle_Shop_Project.Models
{
    [DataContract]
    public class ProducerDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập mã Nhà Sản Xuất")]
        [StringLength(20, ErrorMessage = "mã Nhà Sản Xuất không được vượt quá 20 kí tự")]
        public string Id_Producer { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập tên Nhà Sản Xuất")]
        [StringLength(30, ErrorMessage = "Tên Nhà Sản Xuất không được vượt quá 30 kí tự")]
        public string Producer_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Địa Chỉ")]
        public string Address { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Producer? ProducerData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Producer>? ProducerList { get; set; }
    }
}
