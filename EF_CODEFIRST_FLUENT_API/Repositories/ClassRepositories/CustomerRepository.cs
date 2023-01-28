using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private Connection_DBContext _polyDBContext;
        public CustomerRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Customer obj)
        {
            if (obj == null) return false;
            _polyDBContext.Customers.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Customer obj)
        {
            if (obj == null) return false;
            _polyDBContext.Customers.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Customer obj)
        {
            if (obj == null) return false;
            _polyDBContext.Customers.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Customer> GetAll()
        {
            return _polyDBContext.Customers.ToList();
        }
    }
}
