using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class Save_ProductRepository:ISave_ProductRepository
    {
        private Connection_DBContext _polyDBContext;
        public Save_ProductRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Save_Product obj)
        {
            if (obj == null) return false;
            _polyDBContext.Save_Products.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Save_Product obj)
        {
            if (obj == null) return false;
            _polyDBContext.Save_Products.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Save_Product obj)
        {
            if (obj == null) return false;
            _polyDBContext.Save_Products.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Save_Product> GetAll()
        {
            return _polyDBContext.Save_Products.ToList();
        }
    }
}
