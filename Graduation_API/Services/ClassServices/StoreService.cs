using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class StoreService: IStoreService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IStoreRepository _iStoreRepository;

        public StoreService()
        {
            _iStoreRepository = new StoreRepository();
        }

        public bool Create(Store cv)
        {
            if (cv == null) return false;
            if (_iStoreRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Store cv)
        {
            if (cv == null) return false;
            var temp = _iStoreRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (_iStoreRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Store> GetAll()
        {
            return _iStoreRepository.GetAll();
        }

        public bool Update(Store cv)
        {
            if (cv == null) return false;
            var temp = _iStoreRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            temp.Description = cv.Description;
            temp.Store_Name = cv.Store_Name;
            temp.Address = cv.Address;
            temp.City = cv.City;
            temp.Country = cv.Country;
            temp.Status = cv.Status;
            if (_iStoreRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
