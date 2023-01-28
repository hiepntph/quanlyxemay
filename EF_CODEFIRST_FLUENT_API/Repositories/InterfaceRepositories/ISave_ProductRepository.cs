using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface ISave_ProductRepository
    {
        bool Add(Save_Product obj);
        bool Update(Save_Product obj);
        bool Delete(Save_Product obj);
        List<Save_Product> GetAll();
    }
}
