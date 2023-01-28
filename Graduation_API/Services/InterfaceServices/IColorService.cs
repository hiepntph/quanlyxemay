using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IColorService
    {
        public bool Create(Color cv);

        public bool Update(Color cv);

        public bool Delete(Color cv);

        public List<Color> GetAll();
    }
}
