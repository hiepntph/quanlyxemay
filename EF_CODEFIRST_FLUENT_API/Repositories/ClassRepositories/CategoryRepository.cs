using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private Connection_DBContext _polyDBContext;
        public CategoryRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Category obj)
        {
            if (obj == null) return false;
            _polyDBContext.Categories.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Category obj)
        {
            if (obj == null) return false;
            _polyDBContext.Categories.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Category obj)
        {
            if (obj == null) return false;
            _polyDBContext.Categories.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Category> GetAll()
        {
            return _polyDBContext.Categories.ToList();
        }
    }
}
