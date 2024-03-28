using Microsoft.EntityFrameworkCore;
using NETCORE_Lesson10.Models;

namespace NETCORE_Lesson10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectString = builder.Configuration.GetConnectionString("AppconnectString");
            builder.Services.AddDbContext<Lesson10DbContext>(x => x.UseSqlServer(connectString));

            // Cấu hình sử dụng session
            builder.Services.AddDistributedMemoryCache();
            //đăng ký sử dụng dịch vụ AddHttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = ".Devmaster.Session";
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // sử dụng session đã khai báo
            app.UseSession();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}