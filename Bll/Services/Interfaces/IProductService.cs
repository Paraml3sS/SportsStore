using System.Linq;
using Dto;

namespace Bll.Services.Interfaces
{
    public interface IProductService
    {
        ProductDto Get(int id);
        IQueryable<ProductDto> Get();
        int Count();
        int CountInCategory(string category);
        IQueryable<string> GetCategories();

    }
}
