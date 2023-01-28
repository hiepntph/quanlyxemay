
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
    public class PositionController : Controller
    {
        private IPositionService iPositionService;
        public PositionController()
        {
            iPositionService = new PositionService();
        }

        [HttpGet]
        public async Task<ActionResult> PositionPage()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Position>(String.Concat(Commons.mylocalhost, "Position/get-all-Position"));
                var data = new PositionDTO() { PositionList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm mới chức vụ
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PositionCUPage(PositionDTO Position)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = "";
                    var prd = new Position()
                    {
                        Id = Position.Id,
                        Position_Id = Position.Position_Id,
                        Position_Name = Position.Position_Name,
                        Description = Position.Description
                    };
                    if (Position.Id == Guid.Empty || Position.Id == null) { url = String.Concat(Commons.mylocalhost, "Position/add-Position"); }
                    else { url = String.Concat(Commons.mylocalhost, "Position/update-Position"); }

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(prd, url);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("PositionPage");
                }
                else
                {
                    var lstObjs = await Commons.GetAll<Position>(String.Concat(Commons.mylocalhost, "Position/get-all-Position"));
                    var data = new PositionDTO() { PositionList = lstObjs };
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
        /// Chi tiết chức vụ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var Position = iPositionService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new PositionDTO()
                {
                    PositionList = iPositionService.GetAll(),
                    PositionData = Position,
                    Id = Position.Id,
                    Position_Id = Position.Position_Id,
                    Position_Name = Position.Position_Name,
                    Description = Position.Description
                };
                return View("PositionPage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa chức vụ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = String.Concat(Commons.mylocalhost, "Position/delete-Position?id=", id.NullToString());
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);
                return RedirectToAction("PositionPage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
