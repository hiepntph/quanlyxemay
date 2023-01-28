using EF_CODEFIRST_FLUENT_API.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo
{
    public interface ICategoryRepository
    {
        bool Add(Category obj);
        bool Update(Category obj);
        bool Delete(Category obj);
        List<Category> GetAll();
    }
}
