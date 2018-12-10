using System.Linq;

namespace Bll.Interfaces
{
    public interface IProductService
    {
        IQueryable GetAll();
    }
}
