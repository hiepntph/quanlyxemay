using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IPositionService
    {
        public bool Create(Position cv);

        public bool Update(Position cv);

        public bool Delete(Position cv);

        public List<Position> GetAll();
    }
}
