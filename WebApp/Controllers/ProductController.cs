using System.Linq;
using Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Viewmodels;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 5;

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult List(int productPage = 1) =>

            View(
                new ProductListViewModel {

                Products = _productService.Get()
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _productService.Count()
                }
            });
    }
}
