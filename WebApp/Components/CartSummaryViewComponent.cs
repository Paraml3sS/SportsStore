using Bll.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke() => View(_cart);
    }
}
