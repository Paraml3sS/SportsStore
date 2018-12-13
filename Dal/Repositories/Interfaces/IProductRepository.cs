using System.Linq;
using Domain;

namespace Dal.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Get();
        int Count();
    }
}
