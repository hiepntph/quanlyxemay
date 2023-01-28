using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private Connection_DBContext _polyDBContext;
        public StoreRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Store obj)
        {
            if (obj == null) return false;
            _polyDBContext.Stores.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Store obj)
        {
            if (obj == null) return false;
            _polyDBContext.Stores.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Store obj)
        {
            if (obj == null) return false;
            _polyDBContext.Stores.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Store> GetAll()
        {
            return _polyDBContext.Stores.ToList();
        }
    }
}
