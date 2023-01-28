using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IInvoice_DetailRepository
    {
        bool Add(Invoice_Detail obj);
        bool Update(Invoice_Detail obj);
        bool Delete(Invoice_Detail obj);
        List<Invoice_Detail> GetAll();
    }
}
