using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Motorcycle_Shop_Project.Models
{
    public class InvoiceDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Invoice_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime? Create_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime? Date_of_Payment { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Tên Khách Hàng không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên Khách Hàng không được vượt quá 100 kí tự")]
        public string Customer_Name { get; set; }
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 kí tự")]
        public string Phone_Number { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string Address { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tổng số tiền")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng số tiền phải là số")]
        public decimal Total_Money { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập số tiền đã thành toán")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá nhập phải là số")]
        public decimal Amound_Paid { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int? Status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Invoice? InvoiceData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Invoice>? InvoiceList { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Keyword { get; set; }
    }
}
