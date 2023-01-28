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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Motorcycle_Shop_Project.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("/user/change-personal-infomation-customer-page")]
        public ActionResult Change_CustomerInfoPage()
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

        [HttpPost]
        public async Task<ActionResult> Change_CustomerInfo(CustomerDTO Customer)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var cus = new Customer(){ Id = Customer.Id, Customer_Id = DateTime.Now.ToString("ddMMyy") + Commons.RandomString(4), Customer_Name = Customer.Customer_Name,Email = Customer.Email, Password = Customer.Password,First_name = Customer.First_name,Middle_name = Customer.Middle_name,Last_name = Customer.Last_name,Date_of_birth = Customer.Date_of_birth,Phone_number = Customer.Phone_number,Address = Customer.Address,City = Customer.City, Country = Customer.Country,Description = Customer.Description};
                    ViewBag.Message = "Successfully !";
                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(cus, String.Concat(Commons.mylocalhost, "Customer/update-Customer"));
                    return RedirectToAction("Change_CustomerInfoPage");
                }
                else{ ViewBag.Message = "Failed !"; return View(); }
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("/user/change-personal-infomation-employee-page")]
        public ActionResult Change_EmployeeInfoPage()
        {
            try
            {
                SetViewBag();
                SetViewBagInt();
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SetViewBag(Guid? selected_id = null)
        {
            try
            {
                StoreService storeService = new StoreService();
                PositionService positionService = new PositionService();
                List<SexDTO> SexSTO = new List<SexDTO>()
                {
                    new SexDTO { ID = 0, Sex = "Nam"},
                    new SexDTO { ID = 1, Sex = "Nữ"},
                };
                List<StatusDTO> StatusSTO = new List<StatusDTO>()
                {
                    new StatusDTO { Status = 0, Status_Name = "Đang làm việc"},
                    new StatusDTO { Status = 1, Status_Name = "Đã Nghỉ việc"},
                };
                ViewBag.Status = new SelectList(StatusSTO, "Status", "Status_Name", selected_id);
                ViewBag.Sex = new SelectList(SexSTO, "ID", "Sex", selected_id);

                ViewBag.Id_Store = new SelectList(storeService.GetAll(), "Id", "Store_Name", selected_id);
                ViewBag.Id_Job = new SelectList(positionService.GetAll(), "Id", "Position_Name", selected_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetViewBagInt(int? selected_id = null)
        {
            try
            {
                List<SexDTO> SexSTO = new List<SexDTO>()
                {
                    new SexDTO { ID = 0, Sex = "Nam"},
                    new SexDTO { ID = 1, Sex = "Nữ"},
                };
                List<StatusDTO> StatusSTO = new List<StatusDTO>()
                {
                    new StatusDTO { Status = 0, Status_Name = "Đang làm việc"},
                    new StatusDTO { Status = 1, Status_Name = "Đã Nghỉ việc"},
                };
                ViewBag.Status = new SelectList(StatusSTO, "Status", "Status_Name", selected_id);
                ViewBag.Sex = new SelectList(SexSTO, "ID", "Sex", selected_id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Change_EmployeeInfo(EmployeeDTO Employee)
        {
            try
            {
                SetViewBag(Employee.Store_Id);
                SetViewBag(Employee.Position_Id);
                SetViewBagInt(Convert.ToInt32(Employee.Sex));
                SetViewBagInt(Employee.Status);
                if (ModelState.IsValid)
                {
                    var emp = new Employee(){ Id = Employee.Id,Store_Id = Employee.Store_Id,Position_Id = Employee.Position_Id,Send_report_Id = Employee.Send_report_Id,Employee_Id = Employee.Employee_Id, Employee_Name = Employee.Employee_Name, Email = Employee.Email,Password = Employee.Password,First_name = Employee.First_name,Middle_name = Employee.Middle_name,Last_name = Employee.Last_name,Sex = Employee.Sex,Date_Of_Birth = Employee.Date_Of_Birth,Date_Of_Join = Employee.Date_Of_Join, Phone_number = Employee.Phone_number,Address = Employee.Address, City = Employee.City,Country = Employee.Country,Status = Employee.Status};

                    await Commons.Add_or_UpdateAsync(emp, String.Concat(Commons.mylocalhost, "Employee/update-Employee"));
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("Change_EmployeeInfoPage");
                }
                else{ ViewBag.Message = "Failed !"; return View(); }
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("/user/register-customer-page")]
        public ActionResult RegisterPage()
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

        [HttpPost]
        public async Task<ActionResult> RegisterCustomer(CustomerDTO Customer)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var cus = new Customer(){ Id = Customer.Id, Customer_Id = DateTime.Now.ToString("ddMMyy") + Commons.RandomString(4), Customer_Name = Customer.Customer_Name,Email = Customer.Email, Password = Customer.Password,First_name = Customer.First_name,Middle_name = Customer.Middle_name, Last_name = Customer.Last_name, Date_of_birth = Customer.Date_of_birth, Phone_number = Customer.Phone_number,Address = Customer.Address, City = Customer.City,Country = Customer.Country, Description = Customer.Description};

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(cus, String.Concat(Commons.mylocalhost, "Customer/add-Customer"));
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    ViewBag.Message = "Failed !";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("/user/forgot-password-page")]
        public ActionResult ForgotPasswordPage()
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

        [HttpPost]
        public async Task<ActionResult> ShowPassword(CustomerDTO user)
        {
            try
            {
                string message = "";
                var lstCustomers = await Commons.GetAll<Customer>(String.Concat(Commons.mylocalhost, "Customer/get-all-Customer"));
                var exist_cus = lstCustomers.Where(c => c.Address.ToLower() == user.Address.ToLower() && c.Email.ToLower() == user.Email.ToLower() && c.Phone_number == user.Phone_number && c.Customer_Name.ToLower() == user.Customer_Name.ToLower()).FirstOrDefault();
                if (exist_cus != null) { message = "Mật khẩu của bạn là: " + exist_cus.Password.NullToString(); }

                var lstEmployees = await Commons.GetAll<Employee>(String.Concat(Commons.mylocalhost, "Employee/get-all-Employee"));
                var exist_emp = lstEmployees.Where(c => c.Address.ToLower() == user.Address.ToLower() && c.Email.ToLower() == user.Email.ToLower() && c.Phone_number == user.Phone_number && c.Employee_Name.ToLower() == user.Customer_Name.ToLower()).FirstOrDefault();
                if (exist_emp != null) { message = "Mật khẩu của bạn là: " + exist_emp.Password.NullToString(); }

                if(exist_cus == null && exist_emp == null) { message = "Không tìm thấy thông tin trùng khớp! Vui lòng nhập lại thông tin"; }
                ViewBag.Message = message;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("/user/change-password")]
        public ActionResult ChangePasswordPage()
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

        [HttpPost]
        public async Task<ActionResult> ChangePassword(UserInfoDTO user)
        {
            try
            {
                string message = "";
                if (ModelState.IsValid == true)
                {
                   
                    var lstCustomers = await Commons.GetAll<Customer>(String.Concat(Commons.mylocalhost, "Customer/get-all-Customer"));
                    var Customer = lstCustomers.Where(c => c.Email.ToLower() == user.Email.ToLower() && c.Password == user.password).FirstOrDefault();
                    if (Customer != null) 
                    {
                        var cus = new Customer() { Id = Customer.Id, Customer_Id = Customer.Customer_Id, Customer_Name = Customer.Customer_Name, Email = Customer.Email, Password = user.new_password, First_name = Customer.First_name, Middle_name = Customer.Middle_name, Last_name = Customer.Last_name, Date_of_birth = Customer.Date_of_birth, Phone_number = Customer.Phone_number, Address = Customer.Address, City = Customer.City, Country = Customer.Country, Description = Customer.Description };

                        //-- GTuwir Request cho thằng kia sử lí
                        await Commons.Add_or_UpdateAsync(cus, String.Concat(Commons.mylocalhost, "Customer/change-password-cus"));
                        message = "Successfully !";
                    }

                    var lstEmployees = await Commons.GetAll<Employee>(String.Concat(Commons.mylocalhost, "Employee/get-all-Employee"));
                    var Employee = lstEmployees.Where(c => c.Email.ToLower() == user.Email.ToLower() && c.Password == user.password).FirstOrDefault();
                    if (Employee != null) 
                    {
                        var emp = new Employee() { Id = Employee.Id, Store_Id = Employee.Store_Id, Position_Id = Employee.Position_Id, Send_report_Id = Employee.Send_report_Id, Employee_Id = Employee.Employee_Id, Employee_Name = Employee.Employee_Name, Email = Employee.Email, Password = user.new_password, First_name = Employee.First_name, Middle_name = Employee.Middle_name, Last_name = Employee.Last_name, Sex = Employee.Sex, Date_Of_Birth = Employee.Date_Of_Birth, Date_Of_Join = Employee.Date_Of_Join, Phone_number = Employee.Phone_number, Address = Employee.Address, City = Employee.City, Country = Employee.Country, Status = Employee.Status };

                        await Commons.Add_or_UpdateAsync(emp, String.Concat(Commons.mylocalhost, "Employee/change-password-emp"));
                        message = "Successfully !";
                    }

                    if (Employee == null && Employee == null) { message = "Không tìm thấy thông tin trùng khớp! Vui lòng nhập lại thông tin"; }
                    
                }
                else
                {
                    message = "Failed !";
                }
                ViewBag.Message = message;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
