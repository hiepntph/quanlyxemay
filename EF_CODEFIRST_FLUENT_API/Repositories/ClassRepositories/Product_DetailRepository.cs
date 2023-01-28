using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class Product_DetailRepository : IProduct_DetailRepository
    {
        private Connection_DBContext _polyDBContext;
        public Product_DetailRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Product_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Product_Details.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Product_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Product_Details.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Product_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Product_Details.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Product_Detail> GetAll()
        {
            return _polyDBContext.Product_Details.ToList();
        }
    }
}
