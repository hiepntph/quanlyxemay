using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IEmployeeRepository
    {
        bool Add(Employee obj);
        bool Update(Employee obj);
        bool Delete(Employee obj);
        List<Employee> GetAll();
    }
}
