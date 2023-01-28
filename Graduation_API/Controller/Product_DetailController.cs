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
    public class Product_DetailController : ControllerBase
    {
        private IProduct_DetailService iProduct_DetailService;

        public Product_DetailController()
        {
            iProduct_DetailService = new Product_DetailService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Product_Detail")]
        public List<Product_Detail> GetProduct_Detail()
        {
            try
            {
                return iProduct_DetailService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Product_Detail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-Product_Detail")]
        public bool AddProduct_Detail([FromBody] Product_Detail Product_Detail)
        {
            try
            {
                iProduct_DetailService.Create(Product_Detail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //SqlException: The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Product_Detail_Product_Product_Id". The conflict occurred in database "DB_ASM_CSHARP5_2", table "dbo.Product", column 'Id'.
        //The statement has been terminated.
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="Product_Detail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-Product_Detail")]
        public bool UpdateProduct_Detail([FromBody] Product_Detail Product_Detail)
        {
            try
            {
                iProduct_DetailService.Update(Product_Detail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [Route("update-Product_Detail-quantity-instock")]
        [HttpPost]
        public bool UpdateQuantity_Instock([FromBody] Product_Detail Product_Detail)
        {
            try
            {
                iProduct_DetailService.UpdateQuantityInstock(Product_Detail);
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
        ///// <param name="Product_Detail"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("delete-Product_Detail")]
        //public bool DeleteProduct_Detail(Guid id)
        //{
        //    try
        //    {
        //        var prd = iProduct_DetailService.GetAll().FirstOrDefault(c => c.Id == id);
        //        if (prd != null)
        //        {
        //            //-- Xóa bỏ từng thằng trong cart_Detail có id product_detail như vậy
        //            var cart_detail = iCart_DetailService.GetAll().Where(c => c.Id_Product_Detail == prd.Id).ToList();
        //            if (cart_detail.Count > 0)
        //            {
        //                foreach (var cart_dt in cart_detail)
        //                {
        //                    iCart_DetailService.Delete(cart_dt);
        //                }
        //            }

        //            //-- Xóa bỏ từng thằng trong invoice_Detail có id product_detail như vậy
        //            var invoice_detail = iInvoice_DetailService.GetAll().Where(c => c.Id_Product_Detail == prd.Id).ToList();
        //            if (invoice_detail.Count > 0)
        //            {
        //                foreach (var inv_dt in invoice_detail)
        //                {
        //                    iInvoice_DetailService.Delete(inv_dt);
        //                }
        //            }

        //            //-- Giờ mới xóa Product_detail
        //            iProduct_DetailService.Delete(prd);
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
