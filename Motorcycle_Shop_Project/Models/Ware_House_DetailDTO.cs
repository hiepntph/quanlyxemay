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
    public class Ware_House_DetailDTO
    {
        public Guid Ware_House_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Product_Detail_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int Quantity_entered { get; set; }//Số lượng nhập vao kho
        [DataMember(EmitDefaultValue = false)]
        public int Quantity_in_stock { get; set; }//Số lượng còn lại trong kho
        public Ware_House_Detail Ware_House_DetailData { get; set; }
        public List<Ware_House_Detail> Ware_House_DetailList { get; set; }
        public string phone_number { get; set; }
    }
}
