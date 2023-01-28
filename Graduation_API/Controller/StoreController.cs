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
    public class StoreController : ControllerBase
    {
        private IStoreService iStoreService;
        // GET: api/<SanPhamsController>

        public StoreController()
        {
            iStoreService = new StoreService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-store")]
        public List<Store> GetStore()
        {
            try
            {
                return iStoreService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-Store")]
        public bool AddStore([FromBody]Store Store)
        {
            try
            {
                iStoreService.Create(Store);
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
        /// <param name="Store"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-Store")]
        public bool UpdateStore([FromBody] Store Store)
        {
            try
            {
                iStoreService.Update(Store);
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
        ///// <param name="Store"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("delete-store")]
        //public bool DeleteStore(Guid id)
        //{
        //    try
        //    {
        //        var prd = iStoreService.GetAll().FirstOrDefault(c => c.Id == id);
        //        if (prd != null)
        //        {
        //            //-- Lấy danh sách của nhân viên có chức vụ này
        //            var emp = iEmployeeService.GetAll().Where(c => c.Id_Store == prd.Id).ToList();
        //            if (emp.Count > 0)
        //            {
        //                foreach (var empp in emp)
        //                {
        //                    //-- 2. Xóa các invoice và invoice detail của nhân viên này
        //                    var inv = iInvoiceService.GetAll().Where(c => c.Id_Employee == empp.Id).ToList();
        //                    if (inv.Count > 0)
        //                    {
        //                        //-- 2.1.Xóa từng invoice có id của nhân viên đó
        //                        foreach (var item in inv)
        //                        {
        //                            //-- 2.2.trước hết xóa các invoice chi tiết đã
        //                            var inv_detail = iInvoice_DetailService.GetAll().Where(c => c.Id_Invoice == item.Id).ToList();
        //                            if (inv_detail.Count > 0)
        //                            {
        //                                foreach (var inv_dt in inv_detail)
        //                                {
        //                                    iInvoice_DetailService.Delete(inv_dt);
        //                                }
        //                            }

        //                            //-- 2.3.Sau đó xóa Invoice
        //                            iInvoiceService.Delete(item);
        //                        }
        //                    }

        //                    //-- Xóa nhân viên
        //                    iEmployeeService.Delete(empp);
        //                }
        //            }

        //            iStoreService.Delete(prd);
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
