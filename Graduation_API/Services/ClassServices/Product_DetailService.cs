using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class Product_DetailService:IProduct_DetailService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IProduct_DetailRepository _iProduct_DetailRepository;

        public Product_DetailService()
        {
            _iProduct_DetailRepository = new Product_DetailRepository();
        }

        public bool Create(Product_Detail cv)
        {
            if (cv == null) return false;
            if (_iProduct_DetailRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Product_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iProduct_DetailRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp != null)
            {
                _iProduct_DetailRepository.Delete(temp);
                return true;
            }
            return false;
        }

        public List<Product_Detail> GetAll()
        {
            return _iProduct_DetailRepository.GetAll();
        }

        public bool Update(Product_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iProduct_DetailRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Producer_Id = cv.Producer_Id;
            temp.Product_Id = cv.Product_Id;
            temp.Color_Id = cv.Color_Id;
            temp.Category_Id = cv.Category_Id;
            temp.Date_Of_Manufacture = cv.Date_Of_Manufacture;
            temp.Expiry = cv.Expiry;
            temp.Quantity_in_stock = cv.Quantity_in_stock;
            temp.Import_Price = cv.Import_Price;
            temp.Date_Of_entry = cv.Date_Of_entry;
            temp.Date_Of_inventory = cv.Date_Of_inventory;
            temp.Month_Warranty = cv.Month_Warranty;
            temp.Origin = cv.Origin;
            temp.Description = cv.Description;
            temp.Image = cv.Image;
            temp.Price = cv.Price;
            if (_iProduct_DetailRepository.Update(temp))
            {
                return true;
            }
            return false;
        }

        public bool UpdateQuantityInstock(Product_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iProduct_DetailRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Quantity_in_stock = cv.Quantity_in_stock -1;
            if (_iProduct_DetailRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
