using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class Ware_HouseRepository : IWare_HouseRepository
    {
        private Connection_DBContext _polyDBContext;
        public Ware_HouseRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Ware_House obj)
        {
            if (obj == null) return false;
            _polyDBContext.Ware_Houses.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Ware_House obj)
        {
            if (obj == null) return false;
            _polyDBContext.Ware_Houses.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Ware_House obj)
        {
            if (obj == null) return false;
            _polyDBContext.Ware_Houses.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Ware_House> GetAll()
        {
            return _polyDBContext.Ware_Houses.ToList();
        }
    }
}
