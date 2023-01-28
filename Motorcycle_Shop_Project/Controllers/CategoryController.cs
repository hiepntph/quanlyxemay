
using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Motorcycle_Shop_Project.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService iCategoryService;
        public CategoryController()
        {
            iCategoryService = new CategoryService();
        }

        [HttpGet]
        public async Task<ActionResult> CategoryPage()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var data = new CategoryDTO() { Product_LineList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm mới dòng sản phẩm
        /// </summary>
        /// <param name="Product_Line"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CategoryCUPage(CategoryDTO Product_Line)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    string url = "";
                    var prd = new Category()
                    {
                        Id = Product_Line.Id,
                        Category_Id = Product_Line.Category_id,
                        Category_Name = Product_Line.Category_Name,
                        Description = Product_Line.Description
                    };
                    if (Product_Line.Id == Guid.Empty || Product_Line.Id == null) { url = String.Concat(Commons.mylocalhost, "Category/add-category"); }
                    else { url = String.Concat(Commons.mylocalhost, "Category/update-category"); }
                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(prd, url);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("CategoryPage");
                }
                else 
                {
                    var lstObjs = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                    var data = new CategoryDTO() { Product_LineList = lstObjs };
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
        /// Chi tiết dòng sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var Product_Line = iCategoryService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new CategoryDTO()
                {
                    Product_LineList = iCategoryService.GetAll(),
                    CategoryData = Product_Line,
                    Id = Product_Line.Id,
                    Category_id = Product_Line.Category_Id,
                    Category_Name = Product_Line.Category_Name,
                    Description = Product_Line.Description
                };
                return View("CategoryPage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa dòng sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Category/delete-Category?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);

                return RedirectToAction("CategoryPage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
