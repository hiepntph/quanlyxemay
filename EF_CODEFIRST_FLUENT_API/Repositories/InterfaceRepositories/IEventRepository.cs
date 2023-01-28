using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IEventRepository
    {
        bool Add(Event obj);
        bool Update(Event obj);
        bool Delete(Event obj);
        List<Event> GetAll();
    }
}
