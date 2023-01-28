
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
using Motorcycle_Shop_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Motorcycle_Shop_Project.Controllers
{
    public class StoreController : Controller
    {
        private IStoreService iStoreService;
        public StoreController()
        {
            iStoreService = new StoreService();
        }

        [HttpGet]
        public async Task<ActionResult> StorePage()
        {
            try
            {
                SetViewBagInt();
                var lstObjs = await Commons.GetAll<Store>(String.Concat(Commons.mylocalhost, "Store/get-all-store"));
                var data = new StoreDTO() { StoreList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetViewBagInt(int? selected_id = null)
        {
            List<SexDTO> SexSTO = new List<SexDTO>()
            {
                new SexDTO { ID = 0, Sex = "Nam"},
                new SexDTO { ID = 1, Sex = "Nữ"},
            };
            List<StatusDTO> StatusSTO = new List<StatusDTO>()
            {
                new StatusDTO { Status = 0, Status_Name = "Không hoạt động"},
                new StatusDTO { Status = 1, Status_Name = "Đang hoạt động"},
            };
            ViewBag.Status = new SelectList(StatusSTO, "Status", "Status_Name", selected_id);
            ViewBag.Sex = new SelectList(SexSTO, "ID", "Sex", selected_id);
        }
        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> StoreCUPage(StoreDTO Store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SetViewBagInt(Store.Status);
                    string url = "";
                    //-- Chuẩn hóa dữ liệu
                    var store = new Store()
                    {
                        Id = Store.Id,
                        Store_Id = Store.Store_Id,
                        Store_Name = Store.Store_Name,
                        Address = Store.Address,
                        City = Store.City,
                        Country = Store.Country,
                        Status = Store.Status,
                        Description = Store.Description
                    };

                    //-- Xác thực xem là Create hay update
                    if (Store.Id == Guid.Empty || Store.Id == null) { url = String.Concat(Commons.mylocalhost, "Store/add-store"); }
                    else { url = String.Concat(Commons.mylocalhost, "Store/update-store"); }

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(store, url);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("StorePage");
                }
                else
                {
                    var lstObjs = await Commons.GetAll<Store>(String.Concat(Commons.mylocalhost, "Store/get-all-store"));
                    var data = new StoreDTO() { StoreList = lstObjs };
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
        /// Chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var Store = iStoreService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new StoreDTO()
                {
                    StoreList = iStoreService.GetAll(),
                    StoreData = Store,
                    Id = Store.Id,
                    Store_Id = Store.Store_Id,
                    Store_Name = Store.Store_Name,
                    Address = Store.Address,
                    City = Store.City,
                    Country = Store.Country,
                    Status = Store.Status,
                    Description = Store.Description
                };
                return View("StorePage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Store/delete-store?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("StorePage");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
