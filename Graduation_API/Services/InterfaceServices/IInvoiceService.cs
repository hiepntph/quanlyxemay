using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IInvoiceService
    {
        public bool Create(Invoice cv);

        public bool Update(Invoice cv);

        public bool Delete(Invoice cv);

        public List<Invoice> GetAll();
    }
}
