using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;

namespace Graduation_API.Services.InterfaceServices
{
    public interface ICategoryService
    {
        public bool Create(Category cv);

        public bool Update(Category cv);

        public bool Delete(Category cv);

        public List<Category> GetAll();
    }
}
