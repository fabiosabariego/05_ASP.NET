using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Repository;
using Fiap.Web.AspNet5.Repository.Interface;
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
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true));
            // ****************************************************************************

            // ****************************************************************************
            // Injecao de Dependencias
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
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