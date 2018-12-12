using System.Linq;
using Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            View(_productService.GetAll()
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize)
                );
    }
}
