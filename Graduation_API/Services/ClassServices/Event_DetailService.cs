using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class Event_DetailService:IEvent_DetailService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IEvent_DetailRepository _iEvent_DetailRepository;

        public Event_DetailService()
        {
            _iEvent_DetailRepository = new Event_DetailRepository();
        }

        public bool Create(Event_Detail cv)
        {
            if (cv == null) return false;
            if (_iEvent_DetailRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Event_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iEvent_DetailRepository.GetAll().FirstOrDefault(c => c.Event_Id == cv.Event_Id && c.Product_Detail_Id == cv.Product_Detail_Id);
            if (temp == null) return false; 
            if (_iEvent_DetailRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Event_Detail> GetAll()
        {
            return _iEvent_DetailRepository.GetAll();
        }

        public bool Update(Event_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iEvent_DetailRepository.GetAll().FirstOrDefault(c => c.Event_Id == cv.Event_Id && c.Product_Detail_Id == cv.Product_Detail_Id);
            if (temp == null) return false;
            temp.Status = cv.Status;
            if (_iEvent_DetailRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
