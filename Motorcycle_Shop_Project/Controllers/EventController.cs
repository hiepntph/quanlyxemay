using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Motorcycle_Shop_Project.Helpers;

namespace Motorcycle_Shop_Project.Controllers
{
    public class EventController : Controller
    {
        public EventController()
        {
        }
        /// <summary>
        /// Load dropdown list
        /// </summary>
        /// <param name="selected_id"></param>
        public void SetViewBagInt(int? selected_id = null)
        {
            try
            {
                List<DiscountUnitDTO> dis = new List<DiscountUnitDTO>()
                {
                    new DiscountUnitDTO { Id = 0, Type_Discount = "Giảm theo %"},
                    new DiscountUnitDTO { Id = 1, Type_Discount = "Giảm theo VNĐ"},
                };
                List<StatusDTO> StatusSTO = new List<StatusDTO>()
                {
                    new StatusDTO { Status = 0, Status_Name = "Chưa diễn ra"},
                    new StatusDTO { Status = 1, Status_Name = "Đang diễn ra"},
                    new StatusDTO { Status = 2, Status_Name = "Đã kết thúc"},
                };
                ViewBag.Status = new SelectList(StatusSTO, "Status", "Status_Name", selected_id);
                ViewBag.Discount_Unit = new SelectList(dis, "Id", "Type_Discount", selected_id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Trang hiển thi dánh ách sự kiện
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowAllEvent()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Event>(string.Concat(Commons.mylocalhost, "Event/get-all-Event-active"));
                var data = new EventDTO() { EventLists = lstObjs };
                ViewBag.Dataa = data;
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Hiên thị tát cả những sự kiện đang diễn ra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowAllEventActive()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Event>(string.Concat(Commons.mylocalhost, "Event/get-all-Event-active"));
                var data = new EventDTO() { EventLists = lstObjs };
                ViewBag.Dataa = data;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Tìm kiếm sự kiện
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SearchEvent(EventDTO ev)
        {
            try
            {
                var lstObjs = await Commons.GetAll<Event>(string.Concat(Commons.mylocalhost, "Event/search-event-by-name?keyword=", ev.Event_Name));
                var lstData = new EventDTO() { EventLists = lstObjs };
                ViewBag.Dataa = lstData;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Hiển thị trang quản lí
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EventPage()
        {
            try
            {
                SetViewBagInt();
                Event events = Commons.GetObjectFromJson<Event>(HttpContext.Session, "Eventdata");
                double money = 0;
                if (events != null || events.NullToString() != "")
                {
                    money = events.Discount_Rate.NullToDouble();
                }

                var results = await Commons.GetAll<Product_Detail>(string.Concat(Commons.mylocalhost, "Event/show-all-product?money=", money));
                var data = new Product_DetailDTO() { Product_DetailList = results };
                ViewBag.Dataa = data;
                Console.WriteLine(results);
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm vào sự kiện
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EventCUPage(EventDTO obj)
        {
            try
            {
                SetViewBagInt(obj.Discount_Unit);
                SetViewBagInt(obj.Status);
                if (ModelState.IsValid && Validate_Discount_Rate(obj.Discount_Unit, obj.Discount_Rate))
                {
                    string image = "";
                    string url = "";
                    string Event_Id = DateTime.Now.ToString("ddMMyy") + Commons.RandomString(4);

                    //--Lấy danh sách sản phẩm để đưa vào giảm giá
                    var lstProduct_Detail = await Commons.GetAll<Product_Detail>(
                                            string.Concat(Commons.mylocalhost, "Event/show-all-product?money=", obj.Discount_Rate.NullToDouble()));
                    var data = new Product_DetailDTO() { Product_DetailList = lstProduct_Detail };
                    ViewBag.lstData = data;

                    //-- Lấy dữ liệu image tải lên
                    if (obj.Image_Upload != null)
                    {
                        string full_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", obj.Image_Upload.FileName);
                        using (var file = new FileStream(full_path, FileMode.Create))
                        {
                            obj.Image_Upload.CopyTo(file);
                        }
                        image = obj.Image_Upload.FileName;
                    }

                    //-- Gán dữ liệu chuẩn
                    var ob = new Event() { Id = obj.Id, Event_Id = Event_Id, Event_Name = obj.Event_Name, Discount_Unit = obj.Discount_Unit, Discount_Rate = obj.Discount_Rate, Start_Date = obj.Start_Date, End_Date = obj.End_Date, Status = obj.Status, Description = obj.Description, Image = image };
                    if (obj.Id == Guid.Empty || obj.Id == null) { url = string.Concat(Commons.mylocalhost, "Event/add-to-Event"); }
                    else { url = string.Concat(Commons.mylocalhost, "Event/update-Event"); }

                    //-- Gửi Request cho thằng kia sử lí
                    await Commons.Add_or_UpdateAsync(ob, url);

                    //-- Sau khi add event xong,lưu lại event id để CU vô sự kiện chi tiết
                    Commons.setObjectAsJson(HttpContext.Session, "lstProduct_Detail", lstProduct_Detail);
                    Commons.setObjectAsJson(HttpContext.Session, "Eventdata", ob);
                    ViewBag.Message = "Successfully !";
                    return RedirectToAction("ProductListPage");
                }
                else
                {
                    var results = await Commons.GetAll<Product_Detail>(string.Concat(Commons.mylocalhost, "Event/show-all-product?money=", obj.Discount_Rate));
                    var data = new Product_DetailDTO() { Product_DetailList = results };
                    ViewBag.Dataa = data;
                    ViewBag.Message = "Failed !";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public async Task<ActionResult> ProductListPage()
        {
            try
            {
                var data = Commons.GetObjectFromJson<Event>(HttpContext.Session, "Eventdata");
                Console.WriteLine(data);
                var lstProduct_Detail = await Commons.GetAll<Product_Detail>(
                                        string.Concat(Commons.mylocalhost, "Event/show-all-product?money=", data.Discount_Rate.NullToDouble()));
                var prdt = new Product_DetailDTO() { Product_DetailList = lstProduct_Detail };
                ViewBag.Dataa = prdt;
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// Thêm vào sự kiện chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddEventDetail(Guid id)
        {
            try
            {
                var eve_data = Commons.GetObjectFromJson<Event>(HttpContext.Session, "Eventdata");
                var lstObjs = await Commons.GetAll<Event>(string.Concat(Commons.mylocalhost, "Event/get-all-Event"));
                var eve = lstObjs.Where(c => c.Event_Id == eve_data.Event_Id && c.Event_Name == eve_data.Event_Name).FirstOrDefault();
                Console.WriteLine(eve);
                var ob = new Event_Detail(){ Event_Id = eve.Id, Product_Detail_Id = id,Status = eve.Status };
                Console.WriteLine(ob);
                //--Gửi Request cho thằng kia sử lí
                await Commons.Add_or_UpdateAsync(ob, string.Concat(Commons.mylocalhost, "Event/add-to-Event-detail"));
                return RedirectToAction("ProductListPage");
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// Xem chi tiết sự kiện được chọn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> EventDetail(Guid id)
        {
            try
            {
                //-- Lấy thông tin của sự kiện có id như vậy
                var lstEvents = await Commons.GetAll<EventDTO>(string.Concat(Commons.mylocalhost, "Event/get-all-Event"));
                var events = lstEvents.Where(c => c.Id == id).FirstOrDefault();
                if (events != null)
                {
                    //-- Hiển thị những Event detail của id này,nói đúng hơn là hiển thị danh sách sản phẩm được giảm giá
                    string url = string.Concat(Commons.mylocalhost, "Event/show-event-detail?id=", id);

                    var lstEventDetails = await Commons.GetAll<Event_Detail>(url);
                    //-- Lấy dữ liệu đổ vào table
                    var lstData = new EventDetailDTO() { Event_Details_List = lstEventDetails };
                    ViewBag.EventDetails = lstData;
                    SetViewBagInt(Convert.ToInt32(events.Discount_Unit));
                    SetViewBagInt(Convert.ToInt32(events.Status));
                }
                
                return View(events);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Xóa sản phẩm khỏi sự kiện được chọn
        /// </summary>
        /// <param name="id_product_dt"></param>
        /// <param name="event_id"></param>
        /// <returns></returns>
        public async Task<ActionResult> RemoveEventDetail(Guid id_product_dt, Guid event_id)
        {
            try
            {
                string url = string.Concat(Commons.mylocalhost,"Event/remove-event-detail?id_product_dt=", id_product_dt, "&event_id=", event_id);
                var Rest = new RestSharpHelper(url);
                var respo = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
                Console.WriteLine(respo);
                return RedirectToAction("EventDetail", new { id = event_id });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Validate_Discount_Rate(int discount_unit, decimal? discount_rate)
        {
            if (discount_unit == 0 && discount_rate > 100 || discount_rate == 100 || discount_rate < 0)
            {
                ViewBag.Mess = "false";
                return false;
            }
            else if (discount_unit == 1 && discount_rate > 100000000)
            {
                ViewBag.Mess = "false";
                return false;
            }
            else
            {
                ViewBag.Mess = "true";
                return true;
            }
        }
    }
}
