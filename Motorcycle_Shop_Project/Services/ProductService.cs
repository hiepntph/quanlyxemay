using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using EF_CODEFIRST_FLUENT_API.Repositories;
using Motorcycle_Shop_Project.Models;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;

namespace Motorcycle_Shop_Project.Services
{
    public class ProductService
    {
        private IProduct_DetailRepository _product_DetailRepository = new Product_DetailRepository();
        private IProductRepository _productRepository = new ProductRepository();
        private IColorRepository _colorRepository = new ColorRepository();
        private ICategoryRepository _categoryRepository = new CategoryRepository();
        private IProducerRepository _producerRepository = new ProducerRepository();
        public List<ProductViewModel>? GetAll()
        {
            var result = _product_DetailRepository.GetAll().Join(_productRepository.GetAll(), a => a.Product_Id, b => b.Id, (a, b) => new { a, b }).Join(_colorRepository.GetAll(), c => c.a.Color_Id, d => d.Id, (c, d) => new { c, d }).Join(_categoryRepository.GetAll(), e => e.c.a.Category_Id, f => f.Id, (e, f) => new { e, f }).Join(_producerRepository.GetAll(), g => g.e.c.a.Producer_Id, h => h.Id, (g, h) => new { g, h }).Select(i => new { Producer = i.h, Category = i.g.f, Color = i.g.e.d, Product = i.g.e.c.b, Product_Detail = i.g.e.c.a });
            return JsonConvert.DeserializeObject<List<ProductViewModel>>(JsonConvert.SerializeObject(result));
        }
    }
}
