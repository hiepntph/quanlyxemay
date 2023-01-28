using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Shop_Project.Models
{
    [DataContract]
    public class StoreDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập mã Cửa Hàng")]
        [StringLength(10, ErrorMessage = "Mã Cửa Hàng không được vượt quá 10 kí tự")]
        public string Store_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tên Cửa Hàng")]
        [StringLength(100, ErrorMessage = "Tên Cửa Hàng không được vượt quá 20 kí tự")]
        public string Store_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ")]
        public string Address { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [StringLength(50, ErrorMessage = "Tên thành phố không được vượt quá 50 kí tự")]
        public string? City { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [StringLength(50, ErrorMessage = "Tên Quốc gia không được vượt quá 50 kí tự")]
        public string? Country { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int Status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; } // 0: đang hoạt đông || 1: k hoạt động
        public Store? StoreData { get; set; }
        public List<Store>? StoreList { get; set; }
    }
}
