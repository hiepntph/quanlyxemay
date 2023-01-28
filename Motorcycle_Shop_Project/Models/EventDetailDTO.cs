using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Motorcycle_Shop_Project.Models
{
    public class EventDetailDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Event_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Product_Detail_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int Quantity_Product { get; set; } // Số lượng sản phẩm áp dụng
        [DataMember(EmitDefaultValue = false)]
        public int Status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Product_Detail Product_Detail_Id_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Event_Detail> Event_Details_List { get; set; }
    }
}
