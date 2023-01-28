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
    public class ProducerController : ControllerBase
    {
        private IProducerService iProducerService;

        public ProducerController()
        {
            iProducerService = new ProducerService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Producer")]
        public List<Producer> GetProducer()
        {
            try
            {
                return iProducerService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Producer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-Producer")]
        public bool AddProducer([FromBody]Producer Producer)
        {
            try
            {
                iProducerService.Create(Producer);
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
        /// <param name="Producer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-Producer")]
        public bool UpdateProducer([FromBody] Producer Producer)
        {
            try
            {
                iProducerService.Update(Producer);
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
        ///// <param name="Producer"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("delete-Producer")]
        //public bool DeleteProducer(Guid id)
        //{
        //    try
        //    {
        //        var prd = iProducerService.GetAll().FirstOrDefault(c => c.Id == id);
        //        if (prd != null)
        //        {
        //            var product_detail = iProduct_DetailService.GetAll().Where(c => c.IdProducer == prd.Id).ToList();
        //            if (product_detail.Count > 0)
        //            {
        //                foreach (var item in product_detail)
        //                {
        //                    //-- Xóa bỏ từng thằng trong cart_Detail có id product_detail như vậy
        //                    var cart_detail = iCart_DetailService.GetAll().Where(c => c.Id_Product_Detail == item.Id).ToList();
        //                    if (cart_detail.Count > 0)
        //                    {
        //                        foreach (var cart_dt in cart_detail)
        //                        {
        //                            iCart_DetailService.Delete(cart_dt);
        //                        }
        //                    }

        //                    //-- Xóa bỏ từng thằng trong invoice_Detail có id product_detail như vậy
        //                    var invoice_detail = iInvoice_DetailService.GetAll().Where(c => c.Id_Product_Detail == item.Id).ToList();
        //                    if (invoice_detail.Count > 0)
        //                    {
        //                        foreach (var inv_dt in invoice_detail)
        //                        {
        //                            iInvoice_DetailService.Delete(inv_dt);
        //                        }
        //                    }

        //                    //-- Giờ mới xóa Product_detail
        //                    iProduct_DetailService.Delete(item);
        //                }
        //            }
        //            iProducerService.Delete(prd);
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
