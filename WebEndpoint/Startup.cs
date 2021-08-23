using Application.Confiuration.AutoMapping;
using Application.Products.Interfaces;
using Application.Products.Services;
using Infrastructure.Context;
using Infrastructure.Contracts;
using Infrastructure.IdentityConfig;
using Infrastructure.Repositorie;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEndpoint
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            #region  Connection String
            string connection = Configuration["ConnectionString:SqlServer"];
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connection));
            #endregion
            #region Identity
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredUniqueChars = 0;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.User.RequireUniqueEmail = true;
                option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                option.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityError>();
            services.ConfigureApplicationCookie(opts =>
            {

                opts.LoginPath = "/Login";
                opts.AccessDeniedPath = "/Login";
                opts.ExpireTimeSpan = TimeSpan.FromHours(10);

            });
            #endregion

            services.AddAutoMapper(typeof(AutoMapping));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductCategory, ProductCategoryService>();
            services.AddScoped<IProducts, ProductsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
