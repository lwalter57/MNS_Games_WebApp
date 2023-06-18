using Microsoft.EntityFrameworkCore;
using MNS_Games_WebApplication.Models;

namespace MNS_Games_WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MnsgamesContext>(options =>
                                                    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            builder.Services.AddDistributedMemoryCache();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapDefaultControllerRoute();

            app.MapRazorPages();

            app.Run();
        }
    }
}