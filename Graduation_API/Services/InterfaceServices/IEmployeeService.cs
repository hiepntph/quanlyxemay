using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IEmployeeService
    {
        public bool Create(Employee cv);

        public bool Update(Employee cv);

        public bool Delete(Employee cv);
        public bool ChangePassword(Employee cv);

        public List<Employee> GetAll();
    }
}
