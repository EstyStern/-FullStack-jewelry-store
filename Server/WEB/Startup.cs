using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BLL;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //ADD Cors
            services.AddCors(p => p.AddPolicy("AlowAll", option =>
            {
                option.AllowAnyMethod();
                option.AllowAnyHeader();
                option.AllowAnyOrigin();
            }));

            //ADD Scoped

            services.AddScoped(typeof(ICustomers_DAL), typeof(Customers_DAL));
            services.AddScoped(typeof(ICustomers_BLL), typeof(Customers_BLL));

            services.AddScoped(typeof(ICategory_DAL), typeof(Category_DAL));
            services.AddScoped(typeof(ICategory_BLL), typeof(Category_BLL));

            services.AddScoped(typeof(IJewelry_DAL), typeof(Jewelry_DAL));
            services.AddScoped(typeof(IJewelry_BLL), typeof(Jewelry_BLL));

            services.AddScoped(typeof(ICartBLL), typeof(CartBLL));

            services.AddScoped(typeof(IShoppingDAL), typeof(ShoppingDAL));
            services.AddScoped(typeof(IDetailsShoppingDAL), typeof(DetailsShoppingDAL));



            //ADD DbContext
            //הזרקת מסד הנתונים
            services.AddDbContext<Jewelry_dbContext>(p => p.UseSqlServer("Server=DESKTOP-42NCSL4\\SQLEXPRESS;Database=Jewelry_db;Trusted_Connection=True;"));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseCors("AlowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
