using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace Motorcycle_Shop_Project.Models
{
    [DataContract]
    public class Product_DetailDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Product_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Producer_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Color_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Category_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Column(TypeName = "date")]
        public DateTime? Date_Of_Manufacture { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Column(TypeName = "date")]
        public DateTime? Expiry { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime? Date_Of_entry { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Column(TypeName = "date")]
        public DateTime? Date_Of_inventory { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập số lượng tồn kho")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho phải là số")]
        public int Quantity_in_stock { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập giá nhập")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá nhập phải là số")]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal Import_Price { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập giá bán")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải là số")]
        [Column(TypeName = "decimal(20, 0)")]
        public decimal Price { get; set; }
        [DataMember(EmitDefaultValue = false)]

        [Required(ErrorMessage = "Vui lòng nhập số tháng được bảo hành")]
        [Range(0, int.MaxValue, ErrorMessage = "Số tháng bảo hành phải là số")]
        public int Month_Warranty { get; set; }
        [DataMember(EmitDefaultValue = false)]
        [Required(ErrorMessage = "Vui lòng nhập nguồn gốc xuất sứ")]
        public string Origin { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? Image { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public IFormFile? Image_Upload { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Product_Detail? Product_DetailData { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Product_Detail>? Product_DetailList { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? phone_number { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? customer_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string? customer_name { get; set; }
    }
}
