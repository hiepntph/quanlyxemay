using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class ColorService: IColorService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IColorRepository _iColorRepository;

        public ColorService()
        {
            _iColorRepository = new ColorRepository();
        }

        public bool Create(Color cv)
        {
            if (cv == null) return false;
            if (_iColorRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Color cv)
        {
            if (cv == null) return false;
            var temp = _iColorRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            if (_iColorRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Color> GetAll()
        {
            return _iColorRepository.GetAll();
        }

        public bool Update(Color cv)
        {
            if (cv == null) return false;
            var temp = _iColorRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Color_Name = cv.Color_Name;
            temp.Description = cv.Description;
            if (_iColorRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
