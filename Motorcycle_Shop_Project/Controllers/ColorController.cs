using EF_CODEFIRST_FLUENT_API.DomainClass;
using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Graduation_API.Controllers;

namespace ASM_CSharp4.Controllers
{
    public class ColorController : Controller
    {
        private IColorService iColorService;
        
        public ColorController()
        {
            iColorService = new ColorService();
        }

        [HttpGet]
        public async Task<ActionResult> ColorPage()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Color>(String.Concat(Commons.mylocalhost, "Color/get-all-Color"));
                var data = new ColorDTO() { ColorList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="Color"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ColorCUPage(ColorDTO Color)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    string url = "";
                    var prd = new Color()
                    {
                        Id = Color.Id,
                        Color_Id = Color.Id_Color,
                        Color_Name = Color.Color_Name,
                        Description = Color.Description
                    };
                    if (Color.Id == Guid.Empty || Color.Id == null) { url = string.Concat(Commons.mylocalhost, "Color/add-Color"); }
                    else { url = string.Concat(Commons.mylocalhost, "Color/update-Color"); }
                    ViewBag.Message = "Successfully !";
                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(prd, url);
                    return RedirectToAction("ColorPage");
                }
                else
                {
                    var lstObjs = await Commons.GetAll<Color>(String.Concat(Commons.mylocalhost, "Color/get-all-Color"));
                    var data = new ColorDTO() { ColorList = lstObjs };
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
        /// Chi tiết màu sắc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var lst = iColorService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new ColorDTO()
                {
                    ColorList = iColorService.GetAll(),
                    ColorData = lst,
                    Id = lst.Id,
                    Color_Name = lst.Color_Name,
                    Id_Color = lst.Color_Id,
                    Description = lst.Description
                };

                return View("ColorCUPage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa màu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Color/delete-Color?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("ColorPage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
