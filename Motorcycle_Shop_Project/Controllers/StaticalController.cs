
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Motorcycle_Shop_Project.Helpers;

namespace ASM_CSharp4.Controllers
{
    public class StaticalController : Controller
    {
        public StaticalController()
        {
        }

        [HttpGet]
        public ActionResult StaticalPage()
        {
             return View();
        }


        /// <summary>
        /// Thông kê số liệu theo ngày
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetDatas()
        {
            try
            {
                var lstInvoices = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice>(String.Concat(Commons.mylocalhost, "Invoice/get-all-Invoice"));
                var lstInvoiceDetails = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice_Detail>(String.Concat(Commons.mylocalhost, "Invoice_Detail/get-all-Invoice_Detail"));
                var lstProduct_Details = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));

                //--Thông kê lợi nhuận = Tổng doanh thu - tổng chi phí
                var results = (from b in lstInvoices
                               join bhct in lstInvoiceDetails on b.Id equals bhct.Invoice_Id
                               from s in lstProduct_Details
                               where s.Id == bhct.Product_Detail_Id
                               orderby b.Date_of_Payment ascending
                               group bhct by new
                               {
                                   b.Date_of_Payment.Value.Date
                               }
                                                          into g
                               select new
                               {
                                   Day = g.Key.Date,
                                   TongThanhTien = g.Sum(c => c.Quantity * c.Price),
                                   TongSoLuong = g.Sum(c => c.Quantity),
                                   TongChiPhi = Convert.ToDouble(g.Sum(c => (c.Quantity *
                                                (lstProduct_Details.Where(h => h.Id == c.Product_Detail_Id).Select(h => h.Import_Price).FirstOrDefault()))))
                               }).ToList();
                Console.WriteLine(results);
                return Json(results);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thống kê của nhân viên
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Rank_Employee()
        {
            try
            {
                await GetSalesForEmployee();
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Doanh số của nhân viên theo ngày
        /// </summary>
        /// <returns></returns>
        public async Task GetSalesForEmployee()
        {
            try
            {
                var lstInvoices = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice>(String.Concat(Commons.mylocalhost, "Invoice/get-all-Invoice"));
                var lstInvoiceDetails = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice_Detail>(String.Concat(Commons.mylocalhost, "Invoice_Detail/get-all-Invoice_Detail"));
                var lstEmployees = await Commons.GetAll<Employee>(String.Concat(Commons.mylocalhost, "Employee/get-all-Employee"));

                //--Thông kê lợi nhuận = Tổng doanh thu - tổng chi phí
                var results = (from b in lstInvoices
                               join bhct in lstInvoiceDetails on b.Id equals bhct.Invoice_Id
                               from s in lstEmployees
                               where b.Employee_Id == s.Id
                               orderby b.Date_of_Payment ascending
                               group bhct by new
                               {
                                   s.Employee_Id,
                                   s.Employee_Name,
                                   s.Phone_number,
                                   s.Sex,
                                   b.Date_of_Payment.Value.Date,
                               }
                               into g
                               select new
                               {
                                   Employee_Id = g.Key.Employee_Id,
                                   Employee_Name = g.Key.Employee_Name,
                                   Phone_Number = g.Key.Phone_number,
                                   Sex = g.Key.Sex,
                                   Day = g.Key.Date,
                                   Total_Quantity = g.Count(),
                                   Total_number_Sales = g.Sum(c => c.Quantity)
                               }).ToList();

                List<EmployeeStaticalDTO> lstDatas = new List<EmployeeStaticalDTO>();
                foreach (var item in results.OrderBy(c=>c.Total_number_Sales))
                {
                    var data = new EmployeeStaticalDTO();
                    data.Employee_id = item.Employee_Id;
                    data.Employee_name = item.Employee_Name;
                    data.Phone_number = item.Phone_Number;
                    data.Sex = item.Sex;
                    data.Date = item.Day;
                    data.Total_Quantity = item.Total_Quantity;
                    data.Total_Number_Sales = item.Total_number_Sales.NullToInt();
                    lstDatas.Add(data);
                }
                Console.WriteLine(results);
                ViewData["Data"] = lstDatas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetSales()
        {
            try
            {
                var lstInvoices = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice>(String.Concat(Commons.mylocalhost, "Invoice/get-all-Invoice"));
                var lstInvoiceDetails = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice_Detail>(String.Concat(Commons.mylocalhost, "Invoice_Detail/get-all-Invoice_Detail"));
                var lstEmployees = await Commons.GetAll<Employee>(String.Concat(Commons.mylocalhost, "Employee/get-all-Employee"));
                var user = Commons.GetObjectFromJson<Employee>(HttpContext.Session, "user_info");

                //--Thông kê lợi nhuận = Tổng doanh thu - tổng chi phí
                var results = (from b in lstInvoices
                               join bhct in lstInvoiceDetails on b.Id equals bhct.Invoice_Id
                               from s in lstEmployees
                               where b.Employee_Id == s.Id
                               where b.Employee_Id == user.Id
                               orderby b.Date_of_Payment ascending
                               group bhct by new
                               {
                                   s.Employee_Id,
                                   s.Employee_Name,
                                   s.Phone_number,
                                   s.Sex,
                                   b.Date_of_Payment.Value.Date,
                               }
                               into g
                               select new
                               {
                                   Employee_Id = g.Key.Employee_Id,
                                   Employee_Name = g.Key.Employee_Name,
                                   Phone_Number = g.Key.Phone_number,
                                   Sex = g.Key.Sex,
                                   Day = g.Key.Date,
                                   Total_Quantity = g.Count(),
                                   Total_number_Sales = g.Sum(c => c.Quantity)
                               }).ToList();
                Console.WriteLine(results);
                return Json(results);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Statical_Employee()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
