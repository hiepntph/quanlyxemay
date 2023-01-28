
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;

namespace Motorcycle_Shop_Project.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService iEmployeeService;
        public EmployeeController()
        {
            iEmployeeService = new EmployeeService();
        }

        [HttpGet]
        public async Task<ActionResult> EmployeePage()
        {
            try
            {
                SetViewBag();
                SetViewBagInt();
                var lstObjs = await Commons.GetAll<Employee>(String.Concat(Commons.mylocalhost, "Employee/get-all-Employee"));
                var data = new EmployeeDTO() { EmployeeList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Set view bag đổ dữ liệu vào combobox hoặc dropdown list
        /// </summary>
        /// <param name="selected_id"></param>
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
        /// <summary>
        /// Thêm mới Nhân Viên
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EmployeeCUPage(EmployeeDTO Employee)
        {
            try
            {
                string url = "";
                SetViewBag(Employee.Store_Id);
                SetViewBag(Employee.Position_Id);
                SetViewBagInt(Convert.ToInt32(Employee.Sex));
                SetViewBagInt(Employee.Status);
                if (ModelState.IsValid)
                {
                    var emp = new Employee()
                    {
                        Id = Employee.Id,
                        Store_Id = Employee.Store_Id,
                        Position_Id = Employee.Position_Id,
                        Send_report_Id = Employee.Send_report_Id,
                        Employee_Id = Employee.Employee_Id,
                        Employee_Name = Employee.Employee_Name,
                        Email = Employee.Email,
                        Password = Employee.Password,
                        First_name = Employee.First_name,
                        Middle_name = Employee.Middle_name,
                        Last_name = Employee.Last_name,
                        Sex = Employee.Sex,
                        Date_Of_Birth = Employee.Date_Of_Birth,
                        Date_Of_Join = Employee.Date_Of_Join,
                        Phone_number = Employee.Phone_number,
                        Address = Employee.Address,
                        City = Employee.City,
                        Country = Employee.Country,
                        Status = Employee.Status
                    };
                    if (Employee.Id == Guid.Empty || Employee.Id == null) { url = String.Concat(Commons.mylocalhost, "Employee/add-Employee"); }
                    else { url = String.Concat(Commons.mylocalhost, "Employee/update-Employee"); }

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(emp, url);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("EmployeePage");
                }
                else
                {
                    var lstObjs = await Commons.GetAll<Employee>(String.Concat(Commons.mylocalhost, "Employee/get-all-Employee"));
                    var data = new EmployeeDTO() { EmployeeList = lstObjs };
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
        /// Xem chi tiết Nhân Viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var Employee = iEmployeeService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new EmployeeDTO()
                {
                    EmployeeList = iEmployeeService.GetAll(),
                    EmployeeData = Employee,
                    Id = Employee.Id,
                    Store_Id = Employee.Store_Id,
                    Position_Id = Employee.Position_Id,
                    Send_report_Id = Employee.Send_report_Id,
                    Employee_Id = Employee.Employee_Id,
                    Employee_Name = Employee.Employee_Name,
                    Email = Employee.Email,
                    Password = Employee.Password,
                    First_name = Employee.First_name,
                    Middle_name = Employee.Middle_name,
                    Last_name = Employee.Last_name,
                    Sex = Employee.Sex,
                    Date_Of_Birth = Employee.Date_Of_Birth,
                    Date_Of_Join = Employee.Date_Of_Join,
                    Phone_number = Employee.Phone_number,
                    Address = Employee.Address,
                    City = Employee.City,
                    Country = Employee.Country,
                    Status = Employee.Status
                };
                SetViewBag(data.Store_Id);
                SetViewBag(data.Position_Id);
                SetViewBagInt(Convert.ToInt32(data.Sex));
                SetViewBagInt(data.Status);
                return View("EmployeePage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa Nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Employee/delete-Employee?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("EmployeePage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
