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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASM_CSharp4.Controllers
{
    public class Ware_HouseController : Controller
    {
        #region k có đủ thời gian nên tập trung hoàn thiện các tính năng khác trước
       
        private IWare_HouseService iWare_HouseService;
        
        public Ware_HouseController()
        {
            iWare_HouseService = new Ware_HouseService();
        }

        [HttpGet]
        public async Task<ActionResult> Ware_HousePage()
        {
            try
            {
                SetViewBagInt();
                var lstObjs = await Commons.GetAll<Ware_HouseDTO>(String.Concat(Commons.mylocalhost, "Ware_House/get-all-Ware_House"));
                return View(lstObjs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SetViewBagInt(int? selected_id = null)
        {
            List<StatusDTO> StatusSTO = new List<StatusDTO>()
            {
                new StatusDTO { Status = 0, Status_Name = "Không hoạt động"},
                new StatusDTO { Status = 1, Status_Name = "Đang hoạt động"},
            };
            ViewBag.Status = new SelectList(StatusSTO, "Status", "Status_Name", selected_id);
        }
        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="Ware_House"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Ware_HouseCUPage(Ware_HouseDTO Ware_House)
        {
            try
            {
                SetViewBagInt(Ware_House.Status);
                string url = "";
                List<Ware_House> objs = new List<Ware_House>();
                if (ModelState.IsValid)
                {
                    var prd = new Ware_HouseDTO()
                    {
                        Id = Ware_House.Id,
                        Ware_House_Id = Ware_House.Ware_House_Id,
                        Ware_House_Name = Ware_House.Ware_House_Name,
                        Create_Date = Ware_House.Create_Date,
                        Address = Ware_House.Address,
                        City = Ware_House.City,
                        Country = Ware_House.Country,
                        Status = Ware_House.Status
                    };
                    if (Ware_House.Id == Guid.Empty){ url = string.Concat(Commons.mylocalhost, "Ware_House/add-Ware_House");}
                    else{ url = string.Concat(Commons.mylocalhost, "Ware_House/update-Ware_House"); }

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(prd, url);
                    return RedirectToAction("Ware_HousePage");
                }
                else
                {
                    var lstobjs = new Ware_HouseDTO() { Ware_HouseList = objs };
                    return View(lstobjs);
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
                var Ware_House = iWare_HouseService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new Ware_HouseDTO()
                {
                    Ware_HouseList = iWare_HouseService.GetAll(),
                    Ware_HouseData = Ware_House,
                    Id = Ware_House.Id,
                    Ware_House_Id = Ware_House.Ware_House_Id,
                    Ware_House_Name = Ware_House.Ware_House_Name,
                    Create_Date = Ware_House.Create_Date,
                    Address = Ware_House.Address,
                    City = Ware_House.City,
                    Country = Ware_House.Country,
                    Status = Ware_House.Status
                };
                SetViewBagInt(Ware_House.Status);
                return View("Ware_HouseCUPage", data);
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
                string url = String.Concat(Commons.mylocalhost, "Ware_House/delete-Ware_House?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("Ware_HousePage");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
