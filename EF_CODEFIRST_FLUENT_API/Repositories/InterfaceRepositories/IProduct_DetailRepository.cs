using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IProduct_DetailRepository
    {
        bool Add(Product_Detail obj);
        bool Update(Product_Detail obj);
        bool Delete(Product_Detail obj);
        List<Product_Detail> GetAll();
    }
}
