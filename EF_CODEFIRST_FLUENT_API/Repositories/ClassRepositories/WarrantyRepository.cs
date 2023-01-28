using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class WarrantyRepository : IWarrantyRepository
    {
        private Connection_DBContext _polyDBContext;
        public WarrantyRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Warranty obj)
        {
            if (obj == null) return false;
            _polyDBContext.Warranties.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Warranty obj)
        {
            if (obj == null) return false;
            _polyDBContext.Warranties.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Warranty obj)
        {
            if (obj == null) return false;
            _polyDBContext.Warranties.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Warranty> GetAll()
        {
            return _polyDBContext.Warranties.ToList();
        }
    }
}
