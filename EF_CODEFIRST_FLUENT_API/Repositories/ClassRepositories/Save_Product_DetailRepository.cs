using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class Save_Product_DetailRepository: ISave_Product_DetailRepository
    {
        private Connection_DBContext _polyDBContext;
        public Save_Product_DetailRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }

        public bool Add(Save_Product_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Save_Product_Details.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Save_Product_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Save_Product_Details.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Save_Product_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Save_Product_Details.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Save_Product_Detail> GetAll()
        {
            return _polyDBContext.Save_Product_Details.ToList();
        }

    }
}
