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
    public class Ware_House_Detail
    {
        public Guid Ware_House_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Product_Detail_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int Quantity_entered { get; set; }//Số lượng nhập vao kho
        [DataMember(EmitDefaultValue = false)]
        public int Quantity_in_stock { get; set; }//Số lượng còn lại trong kho
        [DataMember(EmitDefaultValue = false)]
        public Product_Detail Product_Detail_Id_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Ware_House Ware_HouseId_Navigation { get; set; }
    }
}
