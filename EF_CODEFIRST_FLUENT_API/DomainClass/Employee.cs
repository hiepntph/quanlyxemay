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
    public class Employee
    {

        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid Store_Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid Position_Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid? Send_report_Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Mã Nhân Viên")]
        [StringLength(10, ErrorMessage = "Mã Nhân Viên không được vượt quá 10 kí tự")]
        public string Employee_Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Tên nhân viên không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên Nhân Viên không được vượt quá 100 kí tự")]
        public string Employee_Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Email không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 kí tự")]
        public string Email { get; set; }


        [DataMember(EmitDefaultValue = false)]
        [StringLength(50, ErrorMessage = "Mật khẩu không được vượt quá 50 kí tự")]
        public string? Password { get; set; }


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
        public int Sex { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime Date_Of_Birth { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime Date_Of_Join { get; set; }

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
        public int? Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Store? StoreId_Navigation { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Position? PositionId_Navigation { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Employee? Send_ReportId_Navigation { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Invoice>? Invoices { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Employee>? InverseIdSend_ReportNavigations { get; set; }
    }
}
