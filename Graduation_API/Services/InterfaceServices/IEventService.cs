using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IEventService
    {
        public bool Create(Event cv);

        public bool Update(Event cv);

        public bool Delete(Event cv);

        public List<Event> GetAll();
    }
}
