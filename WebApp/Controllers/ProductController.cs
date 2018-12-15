using System.Linq;
using Bll.Services.Interfaces;
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

        public ViewResult List(string category, int productPage = 1) =>

            View(
                new ProductListViewModel {

                Products = _productService.Get()
                    .Where(p => category == null || p.Category == category)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _productService.Count() : _productService.CountInCategory(category)
                },

                CurrentCategory = category
            });
    }
}
