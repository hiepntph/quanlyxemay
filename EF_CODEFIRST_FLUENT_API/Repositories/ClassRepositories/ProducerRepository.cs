using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private Connection_DBContext _polyDBContext;
        public ProducerRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Producer obj)
        {
            if (obj == null) return false;
            _polyDBContext.Producers.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Producer obj)
        {
            if (obj == null) return false;
            _polyDBContext.Producers.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Producer obj)
        {
            if (obj == null) return false;
            _polyDBContext.Producers.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Producer> GetAll()
        {
            return _polyDBContext.Producers.ToList();
        }
    }
}
