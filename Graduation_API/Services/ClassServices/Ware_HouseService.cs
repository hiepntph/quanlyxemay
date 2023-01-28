using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class Ware_HouseService: IWare_HouseService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IWare_HouseRepository _iWare_HouseRepository;

        public Ware_HouseService()
        {
            _iWare_HouseRepository = new Ware_HouseRepository();
        }

        public bool Create(Ware_House cv)
        {
            if (cv == null) return false;
            if (_iWare_HouseRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Ware_House cv)
        {
            if (cv == null) return false;
            var temp = _iWare_HouseRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id); 
            if (temp == null) return false;
            if (_iWare_HouseRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Ware_House> GetAll()
        {
            return _iWare_HouseRepository.GetAll();
        }

        public bool Update(Ware_House cv)
        {
            if (cv == null) return false;
            var temp = _iWare_HouseRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Ware_House_Name = cv.Ware_House_Name;
            temp.Address = cv.Address;
            temp.City = cv.City;
            temp.Country = cv.Country;
            temp.Status = cv.Status;
            if (_iWare_HouseRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
