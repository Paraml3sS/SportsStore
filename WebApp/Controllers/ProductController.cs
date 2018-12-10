using Bll.Interfaces;
using Dal.Repositories.Base;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult List() => View(_productService.GetAll());
    }
}
