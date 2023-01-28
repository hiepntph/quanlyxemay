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
    public class Event_Detail
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid? Event_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Guid Product_Detail_Id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int Status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Product_Detail? Product_Detail_Id_Navigation { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Event? Event_Id_Navigation { get; set; }
    }
}
