using EF_CODEFIRST_FLUENT_API.DomainClass;
using Graduation_API.Helper;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IProduct_DetailService iProduct_DetailService;
        private IEvent_DetailService iEvent_DetailService;
        private IEventService iEventService;

        public EventController()
        {
            iProduct_DetailService = new Product_DetailService();
            iEvent_DetailService = new Event_DetailService();
            iEventService = new EventService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm mà k có trong sự kiện nào đang hoạt động
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("show-all-product")]
        public List<Product_Detail> ShowAllProduct(double money)
        {
            try
            {
                //-- Lấy data cần thiết
                var lstData = (from x in iEventService.GetAll()
                               join y in iEvent_DetailService.GetAll() on x.Id equals y.Event_Id select new
                                {
                                    Id = x.Id,
                                    Event_Id = x.Event_Id,
                                    Product_Detail_Id = y.Product_Detail_Id,
                                    Discount_Unit = x.Discount_Unit,
                                    Discount_Rate = x.Discount_Rate,
                                    Status = x.Status,
                                    Start_Date = x.Start_Date,
                                    End_Date = x.End_Date

                                }).ToList();

                //-- Lấy danh sách sản phẩm chưa được giảm giá hoặc không nằm trong sự kiện có trạng thái là chưa bắt đầu hoặc đang diễn ra
                var objs = (from x in iProduct_DetailService.GetAll()
                            where x.Id != (from y in lstData where y.Product_Detail_Id == x.Id && y.Status != 3 select y.Product_Detail_Id).FirstOrDefault()
                           && x.Price.NullToDouble() > money select x).ToList();
                return objs;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Event-active")]
        public List<Event> ShowAllEventActive()
        {
            try
            {
                return iEventService.GetAll().Where(c=>c.Status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpGet]
        [Route("get-all-Event")]
        public List<Event> ShowAllEvent()
        {
            try
            {
                return iEventService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("get-all-Event-detail")]
        public List<Event_Detail> ShowAllEventDetail()
        {
            try
            {
                return iEvent_DetailService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Khi nhấn chọn sự kiện nào,sẽ hiển thi chi tiết sự kiện đó
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("show-event-detail")]
        public List<Event_Detail> ShowEventDetail(Guid id)
        {
            try
            {
                List<Event_Detail> lst = new List<Event_Detail>();
                var exist = iEventService.GetAll().Where(c => c.Id == id).FirstOrDefault();

                if (exist == null) return lst;
                else { lst = iEvent_DetailService.GetAll().Where(c => c.Event_Id == exist.Id).ToList(); }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Thêm sự kiện
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-to-Event")]
        public bool AddToEvent([FromBody] Event ev)
        {
            try
            {
                iEventService.Create(ev);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        [Route("update-Event")]
        public bool UpdateColor([FromBody] Event ev)
        {
            try
            {
                iEventService.Update(ev);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Thêm vào sự kiện chi tiết
        /// </summary>
        /// <param name="event_detail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-to-Event-detail")]
        public bool AddToEvent_Detail([FromBody] Event_Detail event_detail)
        {
            try
            {
                iEvent_DetailService.Create(event_detail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("search-event-by-name")]
        public List<Event> Search_Event_byName(string keyword)
        {
            try
            {
                List<Event> lst = new List<Event>();
                var result = iEventService.GetAll().Where(c=>c.Event_Name.ToLower().Contains(keyword.ToLower())).ToList();
                if (result.Count > 0) lst = result;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("remove-event-detail")]
        public bool RemoveEventDetails(Guid id_product_dt, Guid event_id)
        {
            try
            {
                var prd = iEvent_DetailService.GetAll().FirstOrDefault(c => c.Product_Detail_Id == id_product_dt && c.Event_Id == event_id);
                iEvent_DetailService.Delete(prd);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
