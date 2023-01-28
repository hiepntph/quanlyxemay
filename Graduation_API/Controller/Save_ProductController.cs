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
    public class Save_ProductController : ControllerBase
    {
        private ISave_ProductService isave_ProductService;

        public Save_ProductController()
        {
            isave_ProductService = new SaveProductService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-save-product")]
        public List<Save_Product> GetAllSaveProduct()
        {
            try
            {     
                var data = isave_ProductService.GetAll();
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
        [Route("add-save-product")]
        public bool AddProduct(Save_Product product)
        {
            try
            {
                isave_ProductService.Create(product);
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
        [Route("update-save-product")]
        public bool UpdateProduct(Save_Product product)
        {
            try
            {
                isave_ProductService.Update(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
