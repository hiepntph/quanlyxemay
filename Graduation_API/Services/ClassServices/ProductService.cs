using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class ProductService:IProductService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IProductRepository _iProductRepository;

        public ProductService()
        {
            _iProductRepository = new ProductRepository();
        }

        public bool Create(Product cv)
        {
            if (cv == null) return false;
            if (_iProductRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Product cv)
        {
            if (cv == null) return false;
            var temp = _iProductRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            if (_iProductRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Product> GetAll()
        {
            return _iProductRepository.GetAll();
        }

        public bool Update(Product cv)
        {
            if (cv == null) return false;
            var temp = _iProductRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Product_Name = cv.Product_Name;
            temp.Description = cv.Description;
            if (_iProductRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
