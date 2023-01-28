using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories
{
    public class Invoice_DetailRepository : IInvoice_DetailRepository
    {
        private Connection_DBContext _polyDBContext;
        public Invoice_DetailRepository()
        {
            _polyDBContext = new Connection_DBContext();
        }
        public bool Add(Invoice_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Invoice_Details.Add(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Delete(Invoice_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Invoice_Details.Remove(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public bool Update(Invoice_Detail obj)
        {
            if (obj == null) return false;
            _polyDBContext.Invoice_Details.Update(obj);
            _polyDBContext.SaveChanges();
            return true;
        }

        public List<Invoice_Detail> GetAll()
        {
            return _polyDBContext.Invoice_Details.ToList();
        }
    }
}
