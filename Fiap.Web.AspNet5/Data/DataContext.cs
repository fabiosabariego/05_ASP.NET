using Fiap.Web.AspNet5.Controllers;
using Fiap.Web.AspNet5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Data

{
    public class DataContext : DbContext
    {

        public DbSet<FornecedorModel> Fornecedores { get; set; }        // Devemos colocar aqui os Models que tem conexão com o banco
        public DbSet<RepresentanteModel> Representantes { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected DataContext()
        {

        }
    }
}
