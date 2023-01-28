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
    public class CategoryController : ControllerBase
    {
        private ICategoryService iCategoryService;

        public CategoryController()
        {
            iCategoryService = new CategoryService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-category")]
        public List<Category> GetProduct_Line()
        {
            try
            {
                return iCategoryService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Product_Line"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-category")]
        public bool AddProduct_Line([FromBody]Category Product_Line)
        {
            try
            {
                iCategoryService.Create(Product_Line);
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
        /// <param name="Product_Line"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-category")]
        public bool UpdateProduct_Line([FromBody] Category Product_Line)
        {
            try
            {
                iCategoryService.Update(Product_Line);
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
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("delete-productline")]
        //public bool DeleteProduct_Line(Guid id)
        //{
        //    try
        //    {
        //        var prd = iProduct_LineService.GetAll().FirstOrDefault(c => c.Id == id);
        //        if (prd != null)
        //        {
        //            var product_detail = iProduct_DetailService.GetAll().Where(c => c.IdProduct_Line == prd.Id).ToList();
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

        //            //-- Cuối cùng mới xóa dòng sản phẩm
        //            iProduct_LineService.Delete(prd);
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
