using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

         

            //Program.cs
            builder.Services.AddDbContext<BankContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefualtConnection")));


            // Add services to the container./ Localization
            builder.Services.AddControllersWithViews()
                            .AddViewLocalization()
                            .AddDataAnnotationsLocalization();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Middle ware for reading the languages :

            var supportedCultures = new[] { "en", "ar" };
            var requestLocalizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture("ar")
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(requestLocalizationOptions);
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
