using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface IPositionRepository
    {
        bool Add(Position obj);
        bool Update(Position obj);
        bool Delete(Position obj);
        List<Position> GetAll();
    }
}
