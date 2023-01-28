using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Microsoft.AspNetCore.Mvc;
using EF_CODEFIRST_FLUENT_API.DomainClass;
namespace Motorcycle_Shop_Project.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Hiển thị trang đăng nhập
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                var data = Commons.GetObjectFromJson<UserInfoDTO>(HttpContext.Session, "user_info");
                if (data != null)
                {
                    return RedirectToAction("Index", "Product");
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Khi click đăng nh
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UserInfoDTO user)
        {
            try
            {
                ViewBag.Error = "Đăng nhập không thành công! Vui lòng nhập lại thông tin đăng nhập!";
                //-- Kiểm tra dữ liệu đầu vào
                if (ModelState.IsValid == true)
                {
                    //-- Khi đăng nhập thành công sẽ lấy sdt và mật khẩu của ng đăng nhập vào
                    EmployeeService emp = new EmployeeService();
                    CustomerService cus = new CustomerService();
                    var empData = emp.Login(user.Email, user.password);
                    var cusData = cus.Login(user.Email, user.password);

                    //-- Kiểm tra thông tin và phân quyền
                    if (empData != null && empData.Id != Guid.Empty && empData.Employee_Id != null)
                    {
                        Commons.setObjectAsJson(HttpContext.Session, "user_info", empData);
                        return RedirectToAction("Load", "Invoice");
                    }
                    else if (cusData != null && cusData.Id != Guid.Empty && cusData.Customer_Id != null)
                    {
                        Commons.setObjectAsJson(HttpContext.Session, "user_info", cusData);
                        return RedirectToAction("Index", "Product");
                    }
                    else {return View(user); }
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Logout()
        {
            try
            {
                if (HttpContext.Session.GetObjectFromJson<Employee>("user_info") != null || HttpContext.Session.GetObjectFromJson<Customer>("user_info") != null)
                {
                    HttpContext.Session.Remove("user_info");
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
