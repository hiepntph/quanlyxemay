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
    public class Invoice
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid? Customer_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid? Employee_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Invoice_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime? Create_Date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime? Date_of_Payment { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Tên Khách Hàng không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên Khách Hàng không được vượt quá 100 kí tự")]
        public string Customer_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 kí tự")]
        public string Phone_Number { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Address { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tổng số tiền")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng số tiền phải là số")]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? Total_Money { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập số tiền đã thành toán")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá nhập phải là số")]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? Amound_Paid { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int? Status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Customer? CustomerId_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Employee? EmployeeId_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Invoice_Detail>? Invoice_Details { get; set; }
    }
}
