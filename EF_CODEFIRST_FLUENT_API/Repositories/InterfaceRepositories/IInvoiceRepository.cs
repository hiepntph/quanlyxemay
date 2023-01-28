using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IInvoiceRepository
    {
        bool Add(Invoice obj);
        bool Update(Invoice obj);
        bool Delete(Invoice obj);
        List<Invoice> GetAll();
    }
}
