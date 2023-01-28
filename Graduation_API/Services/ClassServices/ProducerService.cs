using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class ProducerService:IProducerService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IProducerRepository _iProducerRepository;

        public ProducerService()
        {
            _iProducerRepository = new ProducerRepository();
        }

        public bool Create(Producer cv)
        {
            if (cv == null) return false;
            if (_iProducerRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Producer cv)
        {
            if (cv == null) return false;
            var temp = _iProducerRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            if (_iProducerRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Producer> GetAll()
        {
            return _iProducerRepository.GetAll();
        }

        public bool Update(Producer cv)
        {
            if (cv == null) return false;
            var temp = _iProducerRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Producer_Name = cv.Producer_Name;
            temp.Description = cv.Description;
            if (_iProducerRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
