using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private Connection_DBContext _polyDBContext;
        public EmployeeRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Employee obj)
        {
            if (obj == null) return false;
            _polyDBContext.Employees.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Employee obj)
        {
            if (obj == null) return false;
            _polyDBContext.Employees.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Employee obj)
        {
            if (obj == null) return false;
            _polyDBContext.Employees.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Employee> GetAll()
        {
            return _polyDBContext.Employees.ToList();
        }
    }
}
