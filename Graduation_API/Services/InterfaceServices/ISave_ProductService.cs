using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface ISave_ProductService
    {
        public bool Create(Save_Product cv);

        public bool Update(Save_Product cv);

        public bool Delete(Save_Product cv);

        public List<Save_Product> GetAll();
    }
}
