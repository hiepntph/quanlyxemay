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
    public class Producer
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Mã Nhà Sản Xuất")]
        [StringLength(10, ErrorMessage = "Mã Nhà Sản Xuất không được vượt quá 10 kí tự")]
        public string Producer_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập tên Nhà Sản Xuất")]
        [StringLength(100, ErrorMessage = "Tên Nhà Sản Xuất không được vượt quá 100 kí tự")]
        public string Producer_Name { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập Địa Chỉ")]
        public string Address { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Product_Detail>? Product_Details { get; set; }
    
    
    }
}
