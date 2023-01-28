using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface ISave_Product_DetailRepository
    {
        bool Add(Save_Product_Detail obj);
        bool Update(Save_Product_Detail obj);
        bool Delete(Save_Product_Detail obj);
        List<Save_Product_Detail> GetAll();
    }
}
