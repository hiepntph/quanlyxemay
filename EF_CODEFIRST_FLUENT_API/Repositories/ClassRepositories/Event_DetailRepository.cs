using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class Event_DetailRepository : IEvent_DetailRepository
    {
        private Connection_DBContext _polyDBContext;
        public Event_DetailRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Event_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Event_Details.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Event_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Event_Details.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Event_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Event_Details.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Event_Detail> GetAll()
        {
            return _polyDBContext.Event_Details.ToList();
        }
    }
}
