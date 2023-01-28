
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
    public class ProducerController : Controller
    {
        private IProducerService iProducerService; 
        public ProducerController()
        {
            iProducerService = new ProducerService();
        }

        [HttpGet]
        public async Task<ActionResult> ProducerPage()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Producer>(String.Concat(Commons.mylocalhost, "Producer/get-all-Producer"));
                var lstProducer = new ProducerDTO(){ProducerList = lstObjs };
                return View(lstProducer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm mới NSX
        /// </summary>
        /// <param name="Producer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ProducerCUPage(ProducerDTO Producer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = "";
                    var prd = new Producer()
                    {
                        Id = Producer.Id,
                        Producer_Id = Producer.Id_Producer,
                        Producer_Name = Producer.Producer_Name,
                        Description = Producer.Description,
                        Address = Producer.Address
                    };
                    if (Producer.Id == Guid.Empty || Producer.Id == null) { url = string.Concat(Commons.mylocalhost, "Producer/add-Producer"); }
                    else { url = string.Concat(Commons.mylocalhost, "Producer/update-Color"); }

                    //-- GTuwir Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(prd, url);
                    return RedirectToAction("ProducerPage");
                }
                else
                {
                    var lstObjs = await Commons.GetAll<Producer>(String.Concat(Commons.mylocalhost, "Producer/get-all-Producer"));
                    var lstProducer = new ProducerDTO() { ProducerList = lstObjs };
                    return View(lstProducer);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        /// <summary>
        /// Thêm mới NSX
        /// </summary>
        /// <param name="Producer"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            try
            {
                var Producer = iProducerService.GetAll().FirstOrDefault(c => c.Id == id);
                var data = new ProducerDTO()
                {
                    ProducerList = iProducerService.GetAll(),
                    ProducerData = Producer,
                    Id = Producer.Id,
                    Id_Producer = Producer.Producer_Id,
                    Producer_Name = Producer.Producer_Name,
                    Description = Producer.Description
                };
                return View("ProducerPage", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa bỏ NSX theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                string url = "https://localhost:5001/api/Producer/delete-Producer?id=" + id.NullToString();
                var Rest = new RestSharpHelper(url);
                var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(Response);

                return RedirectToAction("ProducerPage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
