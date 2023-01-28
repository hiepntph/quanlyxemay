using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class Save_Product_DetailService: ISave_Product_DetailService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private ISave_Product_DetailRepository _iSave_Product_DetailRepository;

        public Save_Product_DetailService()
        {
            _iSave_Product_DetailRepository = new Save_Product_DetailRepository();
        }

        public bool Create(Save_Product_Detail cv)
        {
            if (cv == null) return false;
            if (_iSave_Product_DetailRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Save_Product_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iSave_Product_DetailRepository.GetAll().FirstOrDefault(c => c.Product_Detail_Id == cv.Product_Detail_Id && c.Save_Product_Id == cv.Save_Product_Id);
            if (temp == null) return false;
            if (_iSave_Product_DetailRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Save_Product_Detail> GetAll()
        {
            return _iSave_Product_DetailRepository.GetAll();
        }
        public bool Update(Save_Product_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iSave_Product_DetailRepository.GetAll().FirstOrDefault(c => c.Product_Detail_Id == cv.Product_Detail_Id && c.Save_Product_Id == cv.Save_Product_Id);
            if (temp == null) return false;
            if (_iSave_Product_DetailRepository.Update(temp))
            {
                return true;
            }
            return false;
        }

    }
}
