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
    public class Save_Product_DetailController : ControllerBase
    {
        private ISave_Product_DetailService iSave_Product_DetailService;

        public Save_Product_DetailController()
        {
            iSave_Product_DetailService = new Save_Product_DetailService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-save-product-detail")]
        public List<Save_Product_Detail> GetAllSaveProductDetail()
        {
            try
            {     
                var data = iSave_Product_DetailService.GetAll();
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
        [Route("add-save-product-detail")]
        public bool AddSaveProductDetail(Save_Product_Detail product)
        {
            try
            {
                iSave_Product_DetailService.Create(product);
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
        [Route("update-save-product-detail")]
        public bool UpdateSaveProductDetail(Save_Product_Detail product)
        {
            try
            {
                iSave_Product_DetailService.Update(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("delete-save-product-detail")]
        public bool DeleteSave_Product_Detail(Save_Product_Detail obj)
        {
            try
            {
                iSave_Product_DetailService.Delete(obj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
