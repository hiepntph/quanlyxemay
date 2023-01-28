using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class CategoryService: ICategoryService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private ICategoryRepository _iCategoryRepository;

        public CategoryService()
        {
            _iCategoryRepository = new CategoryRepository();
        }

        public bool Create(Category cv)
        {
            if (cv == null) return false;
            if (_iCategoryRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Category cv)
        {
            if (cv == null) return false;
            var temp = _iCategoryRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id); 
            if (temp == null) return false;
            if (_iCategoryRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Category> GetAll()
        {
            return _iCategoryRepository.GetAll();
        }

        public bool Update(Category cv)
        {
            if (cv == null) return false;
            var temp = _iCategoryRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Category_Name = cv.Category_Name;
            temp.Description = cv.Description;
            if (_iCategoryRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
