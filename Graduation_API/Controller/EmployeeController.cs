using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using System;
using System.Linq;

namespace Graduation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService iEmployeeService;
        // GET: api/<SanPhamsController>

        public EmployeeController()
        {
            iEmployeeService = new EmployeeService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Employee")]
        public List<Employee> GetEmployee()
        {
            try
            {
                return iEmployeeService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-Employee")]
        public bool AddEmployee([FromBody]Employee Employee)
        {
            try
            {
                iEmployeeService.Create(Employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-Employee")]
        public bool UpdateEmployee([FromBody] Employee Employee)
        {
            try
            {
                iEmployeeService.Update(Employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("change-password-emp")]
        public bool ChangePassword([FromBody] Employee Employee)
        {
            try
            {
                iEmployeeService.ChangePassword(Employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///// <summary>
        ///// Xóa
        ///// </summary>
        ///// <param name="Employee"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("delete-Employee")]
        //public bool DeleteEmployee(Guid id)
        //{
        //    try
        //    {
        //        var prd = iEmployeeService.GetAll().FirstOrDefault(c => c.Id == id);
        //        if (prd != null)
        //        {
        //            //-- 2. Xóa các invoice và invoice detail của nhân viên này
        //            var inv = iInvoiceService.GetAll().Where(c => c.Id_Employee == prd.Id).ToList();
        //            if (inv.Count > 0)
        //            {
        //                //-- 2.1.Xóa từng invoice có id của nhân viên đó
        //                foreach (var item in inv)
        //                {
        //                    //-- 2.2.trước hết xóa các invoice chi tiết đã
        //                    var inv_detail = iInvoice_DetailService.GetAll().Where(c => c.Id_Invoice == item.Id).ToList();
        //                    if (inv_detail.Count > 0)
        //                    {
        //                        foreach (var inv_dt in inv_detail)
        //                        {
        //                            iInvoice_DetailService.Delete(inv_dt);
        //                        }
        //                    }

        //                    //-- 2.3.Sau đó xóa Invoice
        //                    iInvoiceService.Delete(item);
        //                }
        //            }
        //            iEmployeeService.Delete(prd);
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
