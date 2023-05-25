using AutoMapper;
using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
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
            builder.Services.AddSession();
            // ****************************************************************************

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


            // ****************************************************************************
            var mapperConfig = new AutoMapper.MapperConfiguration(c =>
            {
                c.AllowNullDestinationValues = true;
                c.CreateMap<LoginViewModel, UsuarioModel>();
                c.CreateMap<UsuarioModel, LoginViewModel>();

                c.CreateMap<RepresentanteViewModel, RepresentanteModel>();
                c.CreateMap<RepresentanteModel, RepresentanteViewModel>();
                c.CreateMap<ClienteViewModel, ClienteModel>();

                c.CreateMap<ClienteModel, ClienteViewModel>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            // ****************************************************************************


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            // ****************************************************************************
            app.UseSession();
            // ****************************************************************************

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}