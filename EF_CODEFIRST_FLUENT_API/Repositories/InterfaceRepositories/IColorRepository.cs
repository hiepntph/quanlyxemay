using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IColorRepository
    {
        bool Add(Color obj);
        bool Update(Color obj);
        bool Delete(Color obj);
        List<Color> GetAll();
    }
}
