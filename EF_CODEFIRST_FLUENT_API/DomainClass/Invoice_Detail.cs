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
    public class Invoice_Detail
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid Invoice_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Product_Detail_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int? Quantity { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? Price { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal Unit_price_when_reduced { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập Tổng số tiền")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng số tiền phải là số")]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? Total_Money { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Product_Detail? Product_Detail_IdNavigation { get; set; }
        public Invoice? Invoice_Id_Navigation { get; set; }
    }
}
