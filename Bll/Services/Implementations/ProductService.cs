using System.Linq;
using Bll.Interfaces;
using Bll.Mappings;
using Dal.Repositories.Base;
using Domain;
using Dto;

namespace Bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product> repo)
        {
            _productRepo = repo;
        }

        public IQueryable<ProductDto> GetAll() => Mapper.MapToDto(_productRepo.GetAll());
    }
}
