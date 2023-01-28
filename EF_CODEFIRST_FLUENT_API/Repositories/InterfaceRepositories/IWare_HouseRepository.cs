using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IWare_HouseRepository
    {
        bool Add(Ware_House obj);
        bool Update(Ware_House obj);
        bool Delete(Ware_House obj);
        List<Ware_House> GetAll();
    }
}
