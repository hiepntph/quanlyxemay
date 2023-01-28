using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IProducerRepository
    {
        bool Add(Producer obj);
        bool Update(Producer obj);
        bool Delete(Producer obj);
        List<Producer> GetAll();
    }
}
