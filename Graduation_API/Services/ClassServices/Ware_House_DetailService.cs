using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class Ware_House_DetailService:IWare_House_DetailService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IWare_House_DetailRepository _iWare_House_DetailRepository;

        public Ware_House_DetailService()
        {
            _iWare_House_DetailRepository = new Ware_House_DetailRepository();
        }

        public bool Create(Ware_House_Detail cv)
        {
            if (cv == null) return false;
            if (_iWare_House_DetailRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Ware_House_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iWare_House_DetailRepository.GetAll().FirstOrDefault(c => c.Ware_House_Id == cv.Ware_House_Id && c.Product_Detail_Id == cv.Product_Detail_Id);
            if (temp != null)
            {
                _iWare_House_DetailRepository.Delete(temp);
                return true;
            }
            return false;
        }

        public List<Ware_House_Detail> GetAll()
        {
            return _iWare_House_DetailRepository.GetAll();
        }

        public bool Update(Ware_House_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iWare_House_DetailRepository.GetAll().FirstOrDefault(c => c.Ware_House_Id == cv.Ware_House_Id && c.Product_Detail_Id == cv.Product_Detail_Id);
            if (temp == null) return false;
            temp.Quantity_entered = cv.Quantity_entered;
            temp.Quantity_in_stock = cv.Quantity_in_stock;
            if (_iWare_House_DetailRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
