using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IEvent_DetailService
    {
        public bool Create(Event_Detail cv);

        public bool Update(Event_Detail cv);

        public bool Delete(Event_Detail cv);

        public List<Event_Detail> GetAll();
    }
}
