using System.Linq;
using Bll.Interfaces;
using Bll.Mappings;
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

        public IQueryable<ProductDto> Get() => Mapper.MapToDto(_productRepo.Get());

        public int Count() => _productRepo.Count();
    }
}
