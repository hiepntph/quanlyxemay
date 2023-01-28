using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IWare_House_DetailRepository
    {
        bool Add(Ware_House_Detail obj);
        bool Update(Ware_House_Detail obj);
        bool Delete(Ware_House_Detail obj);
        List<Ware_House_Detail> GetAll();
    }
}
