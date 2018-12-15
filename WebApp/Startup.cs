using Bll.Services;
using Bll.Services.Interfaces;
using Dal.EF;
using Dal.Repositories.Implementations;
using Dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Infrastructure;

namespace WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>(options => options
                .UseSqlServer(
                    Configuration["Data:SportsStoreProducts:ConnectionString"]));

            services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));
            services.AddTransient(typeof(IProductService), typeof(ProductService));
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));

            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List"});

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1});

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1});

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1});

                routes.MapRoute(
                    name: null, template: "{controller=Product}/{action=List}/{id?}");
            });
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
