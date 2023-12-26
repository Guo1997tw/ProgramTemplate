using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PractiseWebsite.Repositorys.Interface;
using PractiseWebsite.Repositorys.Models;
using PractiseWebsite.Repositorys.Repository;
using PractiseWebsite.Services.Interface;
using PractiseWebsite.Services.Services;

namespace PractiseWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DB Connection
            builder.Services.AddDbContext<NorthwindContext>(option => {
                option.UseSqlServer(
                    builder.Configuration.GetConnectionString("Northwind"));
                });

            // DI
            builder.Services.AddScoped<IProductRepositorys, ProductRepositorys>();
            builder.Services.AddScoped<IProductServices, ProductServices>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DI Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
                option.LoginPath = "/Account/CreateAccount";
                option.AccessDeniedPath = "/Account/NotAllow";
			});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			// Use Authentication
			app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}