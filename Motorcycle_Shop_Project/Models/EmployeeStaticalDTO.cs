using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Shop_Project.Models
{
    public class EmployeeStaticalDTO
    {
        public string Employee_id { get; set; }
        public string Employee_name { get; set; }
        public int Sex { get; set; }
        public DateTime Date { get; set; }
        public string Phone_number { get; set; }
        public int Total_Quantity { get; set; }
        public int Total_Number_Sales { get; set; }
    }
}
