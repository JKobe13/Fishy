using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fishy.Infrastructure.DTO.API.Input;
using Fishy.Infrastructure.DTO.API.Output;
using Fishy.Infrastructure.Interfaces.Services;
using Fishy.Infrastructure.Services;
using Fishy.WebApp.ViewModels.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Fishy.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDirectoryBrowser();

            services.AddSingleton<ProductApiService, ProductApiService>();
            services.AddSingleton<IOffersServices, OfferApiService>();
            services.AddSingleton(x => new HttpClient { BaseAddress = new Uri("http://localhost:5000") });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/MyImages"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/MyImages"
            });

            app.UseDeveloperExceptionPage();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
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

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductDto, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, ProductModifyDto>();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
        }
    }
}
