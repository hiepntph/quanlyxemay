using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IInvoice_DetailService
    {
        public bool Create(Invoice_Detail cv);

        public bool Update(Invoice_Detail cv);

        public bool Delete(Invoice_Detail cv);

        public List<Invoice_Detail> GetAll();
    }
}
