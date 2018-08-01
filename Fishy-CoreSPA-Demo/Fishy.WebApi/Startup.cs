using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Fishy.DAL.Repositories;
using Fishy.Infrastructure.Interfaces.Services;
using Fishy.Infrastructure.Services;
using Microsoft.AspNetCore.HttpOverrides;
using System.Linq;
using Fishy.DAL.Models;
using Fishy.Infrastructure.DTO.API.Output;
using Fishy.Infrastructure.DTO.API.Input;

namespace Fishy.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IProductsRepository, ProductsRepository>();
            services.AddSingleton<IOffersRepository, OffersRepository>();

            services.AddSingleton<IProductsServices, ProductsServices>();
            services.AddSingleton<IOffersServices, OffersServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductModifyDto, Product>();
                
            });

            app.Use(async (context, next) =>
            {
                var forwardedPath = context.Request.Headers["X-Forwarded-Path"].FirstOrDefault();
                if (!string.IsNullOrEmpty(forwardedPath))
                {
                    context.Request.PathBase = forwardedPath;
                }

                await next();
            });

            app.UseMvc();
        }
    }
}
