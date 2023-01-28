using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class InvoiceService:IInvoiceService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IInvoiceRepository _iInvoiceRepository;

        public InvoiceService()
        {
            _iInvoiceRepository = new InvoiceRepository();
        }

        public bool Create(Invoice cv)
        {
            if (cv == null) return false;
            if (_iInvoiceRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Invoice cv)
        {
            if (cv == null) return false;
            var temp = _iInvoiceRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id && c.Customer_Id == cv.Customer_Id);
            if (temp == null) return false;
            if (_iInvoiceRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Invoice> GetAll()
        {
            return _iInvoiceRepository.GetAll();
        }

        public bool Update(Invoice cv)
        {
            if (cv == null) return false;
            var temp = _iInvoiceRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id && c.Customer_Id == cv.Customer_Id);
            if (temp == null) return false;
            temp.Status = cv.Status;
            temp.Amound_Paid = cv.Amound_Paid;
            if (_iInvoiceRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
