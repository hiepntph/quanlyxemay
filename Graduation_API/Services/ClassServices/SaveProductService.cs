using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class SaveProductService:ISave_ProductService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private ISave_ProductRepository _iSave_ProductRepository;

        public SaveProductService()
        {
            _iSave_ProductRepository = new Save_ProductRepository();
        }

        public bool Create(Save_Product cv)
        {
            if (cv == null) return false;
            if (_iSave_ProductRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Save_Product cv)
        {
            if (cv == null) return false;
            var temp = _iSave_ProductRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            if (_iSave_ProductRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Save_Product> GetAll()
        {
            return _iSave_ProductRepository.GetAll();
        }

        public bool Update(Save_Product cv)
        {
            if (cv == null) return false;
            var temp = _iSave_ProductRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Description = cv.Description;
            if (_iSave_ProductRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
