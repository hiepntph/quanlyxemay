using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface IProductService
    {
        public bool Create(Product cv);

        public bool Update(Product cv);

        public bool Delete(Product cv);

        public List<Product> GetAll();
    }
}
