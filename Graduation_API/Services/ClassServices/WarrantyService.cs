using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class WarrantyService: IWarrantyService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IWarrantyRepository _iWarrantyRepository;

        public WarrantyService()
        {
            _iWarrantyRepository = new WarrantyRepository();
        }

        public bool Create(Warranty cv)
        {
            if (cv == null) return false;
            if (_iWarrantyRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Warranty cv)
        {
            if (cv == null) return false;
            var temp = _iWarrantyRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id); 
            if (temp == null) return false;
            if (_iWarrantyRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Warranty> GetAll()
        {
            return _iWarrantyRepository.GetAll();
        }

        public bool Update(Warranty cv)
        {
            if (cv == null) return false;
            var temp = _iWarrantyRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.License_Plate = cv.License_Plate;
            temp.Status = cv.Status;
            temp.Description = cv.Description;
            if (_iWarrantyRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
