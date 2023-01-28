using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IProducerService
    {
        public bool Create(Producer cv);

        public bool Update(Producer cv);

        public bool Delete(Producer cv);

        public List<Producer> GetAll();
    }
}
