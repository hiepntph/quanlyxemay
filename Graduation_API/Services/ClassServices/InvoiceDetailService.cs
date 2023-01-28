using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class Invoice_DetailService:IInvoice_DetailService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IInvoice_DetailRepository _iInvoice_DetailRepository;

        public Invoice_DetailService()
        {
            _iInvoice_DetailRepository = new Invoice_DetailRepository();
        }

        public bool Create(Invoice_Detail cv)
        {
            if (cv == null) return false;
            if (_iInvoice_DetailRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Invoice_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iInvoice_DetailRepository.GetAll().FirstOrDefault(c => c.Invoice_Id == cv.Invoice_Id && c.Product_Detail_Id == cv.Product_Detail_Id);
            if (temp == null) return false;
            if (_iInvoice_DetailRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Invoice_Detail> GetAll()
        {
            return _iInvoice_DetailRepository.GetAll();
        }

        public bool Update(Invoice_Detail cv)
        {
            if (cv == null) return false;
            var temp = _iInvoice_DetailRepository.GetAll().FirstOrDefault(c => c.Invoice_Id == cv.Invoice_Id && c.Product_Detail_Id == cv.Product_Detail_Id);
            temp.Quantity = cv.Quantity;
            if (_iInvoice_DetailRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
