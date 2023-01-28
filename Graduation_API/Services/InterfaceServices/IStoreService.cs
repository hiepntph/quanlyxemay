using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IStoreService
    {
        public bool Create(Store cv);

        public bool Update(Store cv);

        public bool Delete(Store cv);

        public List<Store> GetAll();
    }
}
