using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IProductRepository
    {
        bool Add(Product obj);
        bool Update(Product obj);
        bool Delete(Product obj);
        List<Product> GetAll();
    }
}
