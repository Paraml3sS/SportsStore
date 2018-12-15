using Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Viewmodels;

namespace WebApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public NavigationMenuViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(string category) => 
            View(
                new CategoryViewModel {
                Categories = _productService.GetCategories(),
                SelectedCategory = (string) RouteData.Values["category"]
                });
    }
}
