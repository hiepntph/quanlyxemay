using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IWarrantyService
    {
        public bool Create(Warranty cv);

        public bool Update(Warranty cv);

        public bool Delete(Warranty cv);

        public List<Warranty> GetAll();
    }
}
