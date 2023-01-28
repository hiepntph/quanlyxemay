using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Graduation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMGRAPIController : ControllerBase
    {
        private IProductService iProductService;

        public ProductMGRAPIController()
        {
            iProductService = new ProductService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-product")]
        public List<Product> GetProduct()
        {
            try
            {     
                var data = iProductService.GetAll();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-product")]
        public bool AddProduct([FromBody]Product product)
        {
            try
            {
                iProductService.Create(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-product")]
        public bool UpdateProduct([FromBody] Product product)
        {
            try
            {
                iProductService.Update(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///// <summary>
        ///// Thêm mới sản phẩm
        ///// </summary>
        ///// <param name="product"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("delete-product")]
        //public bool DeleteProduct(Guid id)
        //{
        //    try
        //    {
        //        var prd = iProductService.GetAll().FirstOrDefault(c => c.Id == id);
        //        if (prd != null)
        //        {
        //            var product_detail = iProduct_DetailService.GetAll().Where(c => c.IdProduct == prd.Id).ToList();
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

        //            //-- Cuối cùng mới xóa Sản phẩm
        //            iProductService.Delete(prd);
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        [HttpGet]
        [Route("detail-product")]
        public async Task<(Product obj,List<Product> lst)> DetailProduct(Guid id)
        {
            try
            {
                var product = iProductService.GetAll().FirstOrDefault(c => c.Id == id);
                return (product, iProductService.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
