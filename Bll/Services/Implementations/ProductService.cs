using System.Linq;
using Bll.Interfaces;
using Bll.Mappings;
using Dal.Repositories.Base;
using Domain;

namespace Bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product> repo)
        {
            _productRepo = repo;
        }

        public IQueryable GetAll() => Mapper.MapToDto(_productRepo.GetAll());
    }
}
