using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private Connection_DBContext _polyDBContext;
        public EventRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Event obj)
        {
            if (obj == null) return false;
            _polyDBContext.Events.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Event obj)
        {
            if (obj == null) return false;
            _polyDBContext.Events.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Event obj)
        {
            if (obj == null) return false;
            _polyDBContext.Events.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Event> GetAll()
        {
            return _polyDBContext.Events.ToList();
        }
    }
}
