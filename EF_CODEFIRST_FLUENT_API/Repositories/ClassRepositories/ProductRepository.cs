using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private Connection_DBContext _polyDBContext;
        public ProductRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Product obj)
        {
            if (obj == null) return false;
            _polyDBContext.Products.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Product obj)
        {
            if (obj == null) return false;
            _polyDBContext.Products.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Product obj)
        {
            if (obj == null) return false;
            _polyDBContext.Products.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Product> GetAll()
        {
            return _polyDBContext.Products.ToList();
        }
    }
}
