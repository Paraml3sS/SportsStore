using System.Linq;
using Bll.Mappings;
using Bll.Services.Interfaces;
using Dal.Repositories.Interfaces;
using Dto;

namespace Bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository repo)
        {
            _productRepo = repo;
        }

        public ProductDto Get(int id) => Mapper.MapToDto(_productRepo.Get(id));

        public IQueryable<ProductDto> Get() => Mapper.MapToDto(_productRepo.Get());

        public int Count() => _productRepo.Count();

        public int CountInCategory(string category) => _productRepo.CountInCategory(category);

        public IQueryable<string> GetCategories() => _productRepo.GetCategories();
    }
}
