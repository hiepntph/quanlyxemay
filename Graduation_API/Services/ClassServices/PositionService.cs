using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class PositionService:IPositionService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IPositionRepository _iPositionRepository;

        public PositionService()
        {
            _iPositionRepository = new PositionRepository();
        }

        public bool Create(Position cv)
        {
            if (cv == null) return false;
            if (_iPositionRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Position cv)
        {
            if (cv == null) return false;
            var temp = _iPositionRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (_iPositionRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Position> GetAll()
        {
            return _iPositionRepository.GetAll();
        }

        public bool Update(Position cv)
        {
            if (cv == null) return false;
            var temp = _iPositionRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
                        temp.Description = cv.Description;
            temp.Position_Name = cv.Position_Name;
            if (_iPositionRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
