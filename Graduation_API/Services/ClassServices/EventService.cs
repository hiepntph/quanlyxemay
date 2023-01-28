using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class EventService:IEventService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IEventRepository _iEventRepository;

        public EventService()
        {
            _iEventRepository = new EventRepository();
        }

        public bool Create(Event cv)
        {
            if (cv == null) return false;
            if (_iEventRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Event cv)
        {
            if (cv == null) return false;
            var temp = _iEventRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id && c.Event_Id == cv.Event_Id);
            if (temp == null) return false;
            if (_iEventRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Event> GetAll()
        {
            return _iEventRepository.GetAll();
        }

        public bool Update(Event cv)
        {
            if (cv == null) return false;
            var temp = _iEventRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id && c.Event_Id == cv.Event_Id);
            if (temp == null) return false;
            temp.Event_Name = cv.Event_Name;
            temp.Discount_Unit = cv.Discount_Unit;
            temp.Discount_Rate = cv.Discount_Rate;
            temp.End_Date = cv.End_Date;
            temp.Start_Date = cv.Start_Date;
            temp.Description = cv.Description;
            temp.Status = cv.Status;
            if (_iEventRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
