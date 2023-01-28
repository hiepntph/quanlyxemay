using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Motorcycle_Shop_Project.Models
{
    [DataContract]
    public class CustomerDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? Customer_Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Tên Khách Hàng không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên Khách Hàng không được vượt quá 100 kí tự")]
        public string Customer_Name { get; set; }


        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Email không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 kí tự")]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [StringLength(50, ErrorMessage = "Mật khẩu không được vượt quá 50 kí tự")]
        public string Password { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [StringLength(15, ErrorMessage = "Họ không được vượt quá 50 kí tự")]
        public string? First_name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [StringLength(15, ErrorMessage = "Tên đệm không được vượt quá 50 kí tự")]
        public string? Middle_name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [StringLength(15, ErrorMessage = "Tên không được vượt quá 50 kí tự")]
        public string? Last_name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? Date_of_birth { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 kí tự")]
        public string Phone_number { get; set; }


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
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Customer? CustomerData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Customer>? CustomerList { get; set; }
    }
}
