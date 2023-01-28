using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface ICustomerRepository
    {
        bool Add(Customer obj);
        bool Update(Customer obj);
        bool Delete(Customer obj);
        List<Customer> GetAll();
    }
}
