using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IEvent_DetailRepository
    {
        bool Add(Event_Detail obj);
        bool Update(Event_Detail obj);
        bool Delete(Event_Detail obj);
        List<Event_Detail> GetAll();
    }
}
