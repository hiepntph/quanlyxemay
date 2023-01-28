using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private Connection_DBContext _polyDBContext;
        public PositionRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Position obj)
        {
            if (obj == null) return false;
            _polyDBContext.Positions.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Position obj)
        {
            if (obj == null) return false;
            _polyDBContext.Positions.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Position obj)
        {
            if (obj == null) return false;
            _polyDBContext.Positions.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Position> GetAll()
        {
            return _polyDBContext.Positions.ToList();
        }
    }
}
