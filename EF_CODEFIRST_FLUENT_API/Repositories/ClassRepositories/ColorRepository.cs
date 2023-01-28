using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class ColorRepository:IColorRepository
    {
        private Connection_DBContext _polyDBContext;
        public ColorRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Color obj)
        {
            if (obj == null) return false;
            _polyDBContext.Colors.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Color obj)
        {
            if (obj == null) return false;
            _polyDBContext.Colors.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Color obj)
        {
            if (obj == null) return false;
            _polyDBContext.Colors.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Color> GetAll()
        {
            return _polyDBContext.Colors.ToList();
        }
    }
}
