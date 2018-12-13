using System.Linq;
using Dal.EF;
using Dal.Repositories.Base;
using Dal.Repositories.Interfaces;
using Domain;

namespace Dal.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository() : base()
        {
        }

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Product> Get() => _entitySet;

        public int Count() => _entitySet.Count();
    }
}
