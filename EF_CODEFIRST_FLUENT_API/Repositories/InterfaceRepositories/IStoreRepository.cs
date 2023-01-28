using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IStoreRepository
    {
        bool Add(Store obj);
        bool Update(Store obj);
        bool Delete(Store obj);
        List<Store> GetAll();
    }
}
