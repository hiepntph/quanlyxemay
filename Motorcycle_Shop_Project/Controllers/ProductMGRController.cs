using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Graduation_API.Controllers;
using System.Threading.Tasks;

namespace Motorcycle_Shop_Project.Controllers
{
    public class ProductMGRController : Controller
    {
        private IProductService iProductService;
        public ProductMGRController()
        {
            iProductService = new ProductService();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProduct()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Product>(String.Concat(Commons.mylocalhost, "ProductMGRAPI/get-all-product"));
                var data = new ProductDTO() { ProductList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm hoặc sửa sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveProduct(ProductDTO product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = "";
                    //-- Chuẩn hóa dữ liệu
                    var prd = new Product() { Id = product.Id, Product_Id = product.Product_Id, Product_Name = product.Product_Name, Description = product.Description };

                    //-- Xác thực xem là Create hay Update
                    if (product.Id == Guid.Empty || product.Id == null) { url = String.Concat(Commons.mylocalhost, "ProductMGRAPI/add-product"); }
                    else { url = String.Concat(Commons.mylocalhost, "ProductMGRAPI/update-product"); }
                    Console.WriteLine(url);

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(prd, url);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("GetAllProduct");
                }
                else
                {
                    var lstObjs = await Commons.GetAll<Product>(String.Concat(Commons.mylocalhost, "ProductMGRAPI/get-all-product"));
                    var data = new ProductDTO() { ProductList = lstObjs };
                    ViewBag.Message = "Failed !";
                    return View(data);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Chi Tiết sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var product = iProductService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new ProductDTO()
                {
                    ProductList = iProductService.GetAll(),
                    ProductData = product,
                    Id = product.Id,
                    Product_Id = product.Product_Id,
                    Product_Name = product.Product_Name,
                    Description = product.Description
                };
                return View("GetAllProduct", data);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Product/delete-product?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("GetAllProduct");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
