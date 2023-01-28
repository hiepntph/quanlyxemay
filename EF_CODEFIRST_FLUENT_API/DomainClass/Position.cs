using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFIRST_FLUENT_API.DomainClass
{
    [DataContract]
    public class Position
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Mã Chức Vụ")]
        [StringLength(10, ErrorMessage = "Mã Chức Vụ không được vượt quá 10 kí tự")]
        public string Position_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tên Chức Vụ")]
        [StringLength(100, ErrorMessage = "Tên Chức Vụ không được vượt quá 100 kí tự")]
        public string Position_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Employee>? Employees { get; set; }
    }
}
