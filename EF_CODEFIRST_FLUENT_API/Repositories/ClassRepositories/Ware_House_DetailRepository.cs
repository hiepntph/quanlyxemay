using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class Ware_House_DetailRepository : IWare_House_DetailRepository
    {
        private Connection_DBContext _polyDBContext;
        public Ware_House_DetailRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Ware_House_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Ware_House_Details.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Ware_House_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Ware_House_Details.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Ware_House_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Ware_House_Details.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Ware_House_Detail> GetAll()
        {
            return _polyDBContext.Ware_House_Details.ToList();
        }
    }
}
