using Bll.Services;
using Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Infrastructure.Extensions;
using WebApp.Viewmodels;

namespace WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly Cart _cart;

        public CartController(IProductService productService, Cart cart)
        {
            _productService = productService;
            _cart = cart;
        }

        public ViewResult Index(string returnUrl) =>

            View(
                new CartIndexViewModel
                {
                    Cart = _cart,
                    ReturnUrl = returnUrl
                });

        public RedirectToActionResult AddToCart(int id, string returnUrl)
        {
            var product = _productService.Get(id);

            if (product != null)
            {
                _cart.Add(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int id, string returnUrl)
        {
            var product = _productService.Get(id);

            if (product != null)
            {
                _cart.Remove(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }    
    }
}
