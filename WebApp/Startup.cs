using Bll.Interfaces;
using Bll.Services;
using Dal.EF;
using Dal.Repositories.Base;
using Dal.Repositories.Implementations;
using Dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Products/Page{productPage}",
                    defaults: new { Controller = "Product", action = "List"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");
            });
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
