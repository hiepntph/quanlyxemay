using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface ICustomerService
    {
        public bool Create(Customer cv);

        public bool Update(Customer cv);

        public bool Delete(Customer cv);
        public bool ChangePassword(Customer cv);

        public List<Customer> GetAll();
    }
}
