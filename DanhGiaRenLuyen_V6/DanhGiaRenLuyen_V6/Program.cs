using DanhGiaRenLuyen_V6.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DanhGiaRenLuyen_V6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add DbContext
            var conn = builder.Configuration.GetConnectionString("DBConnectString");
            builder.Services.AddDbContext<DanhGiaRenLuyenContext>(x => x.UseSqlServer(conn));

            // Cấu hình sử dụng Session

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(60);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
                option.Cookie.Name = ".DDRL.Session";

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
            //S? d?ng session khai báo
            app.UseSession();

            app.UseAuthorization();
            app.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
             );

            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
