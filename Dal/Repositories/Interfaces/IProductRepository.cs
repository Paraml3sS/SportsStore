using System.Linq;
using Domain;

namespace Dal.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product Get(int id);
        IQueryable<Product> Get();
        int Count();
        int CountInCategory(string category);
        IQueryable<string> GetCategories();
    }
}
