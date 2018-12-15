using System;
using Bll.Services;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApp.Infrastructure.Extensions;

namespace WebApp.Infrastructure
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;

            return cart;
        }

        public override void Add(ProductDto product, int quantity)
        {
            base.Add(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void Remove(ProductDto product)
        {
            base.Remove(product);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
