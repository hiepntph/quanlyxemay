using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IProduct_DetailService
    {
        public bool Create(Product_Detail cv);

        public bool Update(Product_Detail cv);
        public bool UpdateQuantityInstock(Product_Detail cv);

        public bool Delete(Product_Detail cv);

        public List<Product_Detail> GetAll();
    }
}
