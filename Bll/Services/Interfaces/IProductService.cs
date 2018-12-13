using System.Linq;
using Dto;

namespace Bll.Interfaces
{
    public interface IProductService
    {
        IQueryable<ProductDto> Get();
        int Count();
    }
}
