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
    public class ColorController : ControllerBase
    {
        private IColorService iColorService;

        public ColorController()
        {
            iColorService = new ColorService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Color")]
        public List<Color> GetColor()
        {
            try
            {
                return iColorService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Color"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-Color")]
        public bool AddColor([FromBody]Color Color)
        {
            try
            {
                iColorService.Create(Color);
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
        /// <param name="Color"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-Color")]
        public bool UpdateColor([FromBody]Color Color)
        {
            try
            {
                iColorService.Update(Color);
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
        ///// <param name="Color"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("delete-Color")]
        //public bool DeleteColor(Guid id)
        //{
        //    try
        //    {
        //        //-- lấy thông tin color
        //        var color = iColorService.GetAll().FirstOrDefault(c => c.Id == id);
        //        if (color != null)
        //        {
        //            var product_detail = iProduct_DetailService.GetAll().Where(c => c.Co == color.Id).ToList();
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

        //            //-- Cuối cùng mới xóa màu sắc
        //            iColorService.Delete(color);
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
