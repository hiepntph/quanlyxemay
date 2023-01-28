using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private Connection_DBContext _polyDBContext;
        public InvoiceRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Invoice obj)
        {
            if (obj == null) return false;
            _polyDBContext.Invoices.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Invoice obj)
        {
            if (obj == null) return false;
            _polyDBContext.Invoices.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Invoice obj)
        {
            if (obj == null) return false;
            _polyDBContext.Invoices.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Invoice> GetAll()
        {
            return _polyDBContext.Invoices.ToList();
        }
    }
}
