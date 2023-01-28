using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface ISave_Product_DetailService
    {
        public bool Create(Save_Product_Detail cv);

        public bool Update(Save_Product_Detail cv);

        public bool Delete(Save_Product_Detail cv);

        public List<Save_Product_Detail> GetAll();
    }
}
