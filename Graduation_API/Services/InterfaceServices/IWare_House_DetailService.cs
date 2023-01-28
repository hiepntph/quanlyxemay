using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IWare_House_DetailService
    {
        public bool Create(Ware_House_Detail cv);

        public bool Update(Ware_House_Detail cv);

        public bool Delete(Ware_House_Detail cv);

        public List<Ware_House_Detail> GetAll();
    }
}
