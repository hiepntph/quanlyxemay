
using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Motorcycle_Shop_Project.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService iCustomerService;
        //-- Lấy thông tin người đăng nhập vào
        public CustomerController()
        {
            iCustomerService = new CustomerService();
        }

        [HttpGet]
        public async Task<ActionResult> CustomerPage()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Customer>(String.Concat(Commons.mylocalhost, "Customer/get-all-Customer"));
                var data = new CustomerDTO() { CustomerList = lstObjs };
                //ViewBag.Dataa = lstObjs;
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CustomerCUPage(CustomerDTO Customer)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    string url = "";
                    var cus = new Customer()
                    {
                        Id = Customer.Id,
                        Customer_Id = DateTime.Now.ToString("ddMMyy")+Commons.RandomString(4),
                        Customer_Name = Customer.Customer_Name,
                        Email = Customer.Email,
                        Password = Customer.Password,
                        First_name = Customer.First_name,
                        Middle_name = Customer.Middle_name,
                        Last_name = Customer.Last_name,
                        Date_of_birth = Customer.Date_of_birth,
                        Phone_number = Customer.Phone_number,
                        Address = Customer.Address,
                        City = Customer.City,
                        Country = Customer.Country,
                        Description = Customer.Description
                    };
                    if (Customer.Id == Guid.Empty || Customer.Id == null) { url = String.Concat(Commons.mylocalhost, "Customer/add-Customer"); }
                    else { url = String.Concat(Commons.mylocalhost, "Customer/update-Customer"); }

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(cus, url);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("CustomerPage");
                }
                else
                {
                    var lstObjs = await Commons.GetAll<Customer>(String.Concat(Commons.mylocalhost, "Customer/get-all-Customer"));
                    var data = new CustomerDTO() { CustomerList = lstObjs };
                    ViewBag.Message = "Failed !";
                    return View(data);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Chi tiết khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var Customer = iCustomerService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new CustomerDTO()
                {
                    CustomerList = iCustomerService.GetAll(),
                    CustomerData = Customer,
                    Id = Customer.Id,
                    Customer_Id = Customer.Customer_Id,
                    Customer_Name = Customer.Customer_Name,
                    Email = Customer.Email,
                    Password = Customer.Password,
                    First_name = Customer.First_name,
                    Middle_name = Customer.Middle_name,
                    Last_name = Customer.Last_name,
                    Date_of_birth = Customer.Date_of_birth,
                    Phone_number = Customer.Phone_number,
                    Address = Customer.Address,
                    City = Customer.City,
                    Country = Customer.Country,
                    Description = Customer.Description
                };
                return View("CustomerPage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa khách Hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Customer/delete-Customer?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("CustomerPage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
