using Fiap.Web.AspNet5.Data;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // ****************************************************************************
            // Condições Adicionadas na Aula para conectar ao Banco
            var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true)
            );
            // ****************************************************************************


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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