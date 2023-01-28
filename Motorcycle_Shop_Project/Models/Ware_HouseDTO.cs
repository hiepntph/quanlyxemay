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
    public class Ware_HouseDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Mã Nhà Kho")]
        [StringLength(10, ErrorMessage = "Tên Nhà Kho không được vượt quá 10 kí tự")]
        public string Ware_House_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tên Nhà Kho")]
        [StringLength(100, ErrorMessage = "Tên Nhà Kho không được vượt quá 100 kí tự")]
        public string Ware_House_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime? Create_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ")]
        public string Address { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [StringLength(50, ErrorMessage = "Tên thành phố không được vượt quá 50 kí tự")]
        public string? City { get; set; }
        [StringLength(50, ErrorMessage = "Tên Quốc gia không được vượt quá 50 kí tự")]
        public string? Country { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int Status { get; set; }// 0: không hoạt động || 1: đang hoạt động
        public Ware_House Ware_HouseData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Ware_House> Ware_HouseList { get; set; }
    }
}
