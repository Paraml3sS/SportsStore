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

        public Product Get(int id) => _entitySet.Where(p => p.Id == id).FirstOrDefault();

        public IQueryable<Product> Get() => _entitySet;

        public int Count() => _entitySet.Count();

        public int CountInCategory(string category) => _entitySet.Where(p => p.Category == category).Count();

        public IQueryable<string> GetCategories() => _entitySet.Select(p => p.Category).Distinct().OrderByDescending(c => c);

    }
}
