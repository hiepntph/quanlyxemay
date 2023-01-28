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
    public class CustomerController : ControllerBase
    {
        private ICustomerService iCustomerService;
        // GET: api/<SanPhamsController>

        public CustomerController()
        {
            iCustomerService = new CustomerService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Customer")]
        public List<Customer> GetCustomer()
        {
            try
            {
                return iCustomerService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-Customer")]
        public bool AddCustomer([FromBody]Customer Customer)
        {
            try
            {
                iCustomerService.Create(Customer);
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
        /// <param name="Customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("change-password-cus")]
        public bool UpdateCustomer([FromBody] Customer Customer)
        {
            try
            {
                iCustomerService.ChangePassword(Customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }


    ///// <summary>
    ///// Xóa
    ///// </summary>
    ///// <param name="Customer"></param>
    ///// <returns></returns>
    //[HttpDelete]
    //[Route("delete-Customer")]
    //public bool DeleteCustomer(Guid id)
    //{
    //    try
    //    {
    //        var prd = iCustomerService.GetAll().FirstOrDefault(c => c.Id == id);
    //        if (prd != null)
    //        {
    //            //-- 1.Xóa giỏ hàng  và giỏ hàng chi tiết có id khách hàng này
    //            var cart = iCartService.GetAll().Where(c => c.Id_Customer == prd.Id).ToList();
    //            if (cart.Count > 0)
    //            {
    //                //-- 1.1.Xóa từng giỏ hàng có id của khách hàng đó
    //                foreach (var item in cart)
    //                {
    //                    //-- 1.2.trước hết xóa các giỏ hàng chi tiết đã
    //                    var cart_detail = iCart_DetailService.GetAll().Where(c => c.Id_Cart == item.Id).ToList();
    //                    if (cart_detail.Count > 0)
    //                    {
    //                        foreach (var cart_dt in cart_detail)
    //                        {
    //                            iCart_DetailService.Delete(cart_dt);
    //                        }
    //                    }

    //                    //-- 1.3.Sau đó xóa Cart
    //                    iCartService.Delete(item);
    //                }
    //            }

    //            //-- 2. Xóa các invoice và invoice detail của khách hàng này
    //            var inv = iInvoiceService.GetAll().Where(c => c.Id_Customer == prd.Id).ToList();
    //            if (inv.Count > 0)
    //            {
    //                //-- 2.1.Xóa từng invoice có id của khách hàng đó
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

    //            //-- 3.Xóa khách hàng
    //            iCustomerService.Delete(prd);
    //        }
    //        return true;
    //    }
    //    catch (Exception)
    //    {
    //        return false;
    //    }
    //}
}

