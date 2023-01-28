using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IWarrantyRepository
    {
        bool Add(Warranty obj);
        bool Update(Warranty obj);
        bool Delete(Warranty obj);
        List<Warranty> GetAll();
    }
}
