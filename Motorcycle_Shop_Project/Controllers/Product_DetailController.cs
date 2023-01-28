
using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Motorcycle_Shop_Project.Controllers
{
    public class Product_DetailController : Controller
    {
        private IProduct_DetailService iProduct_DetailService;
        public Product_DetailController()
        {
            iProduct_DetailService = new Product_DetailService();
        }

        [HttpGet]
        public async Task<ActionResult> Product_DetailPage()
        {
            try
            {
                SetViewBag();
                var lstObjs = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
                var data = new Product_DetailDTO() { Product_DetailList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Set View Bag đổ dữ liệu vào combobox,dropdownlist
        /// </summary>
        /// <param name="selected_id"></param>
        public void SetViewBag(Guid? selected_id = null)
        {
            try
            {
                ProducerService producerService = new ProducerService();
                ColorService colorService = new ColorService();
                ProductService productService = new ProductService();
                CategoryService product_LineService = new CategoryService();
                ViewBag.IdProduct = new SelectList(productService.GetAll(), "Id", "Product_Name", selected_id);
                ViewBag.IdProducer = new SelectList(producerService.GetAll(), "Id", "Producer_Name", selected_id);
                ViewBag.IdProduct_Line = new SelectList(product_LineService.GetAll(), "Id", "Category_Name", selected_id);
                ViewBag.IdColor = new SelectList(colorService.GetAll(), "Id", "Color_Name", selected_id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="Product_Detail"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Product_DetailCUPage(Product_DetailDTO Product_Detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string image = "";
                    string url = "";
                    List<Product_Detail> objs = new List<Product_Detail>();

                    //-- Lấy dữ liệu image tải lên
                    if (Product_Detail.Image_Upload != null)
                    {
                        string full_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Product_Detail.Image_Upload.FileName);
                        using (var file = new FileStream(full_path, FileMode.Create))
                        {
                            Product_Detail.Image_Upload.CopyTo(file);
                        }
                        image = Product_Detail.Image_Upload.FileName;
                    }

                    SetViewBag(Product_Detail.Color_Id);
                    SetViewBag(Product_Detail.Product_Id);
                    SetViewBag(Product_Detail.Producer_Id);
                    SetViewBag(Product_Detail.Category_Id);

                    var data = new Product_Detail()
                    {
                        Id = Product_Detail.Id,
                        Product_Id = Product_Detail.Product_Id,
                        Producer_Id = Product_Detail.Producer_Id,
                        Color_Id = Product_Detail.Color_Id,
                        Category_Id = Product_Detail.Category_Id,

                        Date_Of_Manufacture = Product_Detail.Date_Of_Manufacture,
                        Expiry = Product_Detail.Expiry,
                        Date_Of_entry = Product_Detail.Date_Of_entry,
                        Date_Of_inventory = Product_Detail.Date_Of_inventory,
                        Quantity_in_stock = Product_Detail.Quantity_in_stock,
                        Import_Price = Product_Detail.Import_Price,
                        Price = Product_Detail.Price,
                        Month_Warranty = Product_Detail.Month_Warranty,
                        Origin = Product_Detail.Origin,
                        Description = Product_Detail.Description,
                        Image = image
                    };

                    if (Product_Detail.Id == Guid.Empty || Product_Detail.Id == null) { url = String.Concat(Commons.mylocalhost, "Product_Detail/add-Product_Detail"); }
                    else { url = String.Concat(Commons.mylocalhost, "Product_Detail/update-Product_Detail"); }

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(data, url);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("Product_DetailPage");
                }
                else
                {
                    ViewBag.Message = "Failed !";
                    var lstObjs = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
                    var data = new Product_DetailDTO() { Product_DetailList = lstObjs };
                    return View(data);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="Product_Detail"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var Product_Detail = iProduct_DetailService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new Product_DetailDTO()
                {
                    Product_DetailList = iProduct_DetailService.GetAll(),
                    Product_DetailData = Product_Detail,
                    Id = Product_Detail.Id,
                    Product_Id = Product_Detail.Producer_Id,
                    Producer_Id = Product_Detail.Producer_Id,
                    Color_Id = Product_Detail.Color_Id,
                    Category_Id = Product_Detail.Category_Id,

                    Date_Of_Manufacture = Product_Detail.Date_Of_Manufacture,
                    Expiry = Product_Detail.Expiry,
                    Date_Of_entry = Product_Detail.Date_Of_entry,
                    Date_Of_inventory = Product_Detail.Date_Of_inventory,
                    Quantity_in_stock = Product_Detail.Quantity_in_stock,
                    Import_Price = Product_Detail.Import_Price,
                    Price = Product_Detail.Price,
                    Month_Warranty = Product_Detail.Month_Warranty,
                    Origin = Product_Detail.Origin,
                    Description = Product_Detail.Description,
                };
                SetViewBag(data.Product_DetailData.Color_Id);
                SetViewBag(data.Product_DetailData.Product_Id);
                SetViewBag(data.Product_DetailData.Producer_Id);
                SetViewBag(data.Product_DetailData.Category_Id);
                return View("Product_DetailPage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Product_Detail/delete-Product_Detail?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("Product_DetailPage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
