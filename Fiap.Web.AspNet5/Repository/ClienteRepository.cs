using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Repository
{
    public class ClienteRepository
    {

        //      CRUD
        // Find By Id (Read)
        // Find All (Read)
        // Insert (Create)
        // Update
        // Delete

        //-------------------------------------------------
        //Criando acesso ao Data Context
        private readonly DataContext dataContext;

        public ClienteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        //-------------------------------------------------

        //Criando Metodo FindAll
        public IList<ClienteModel> FindAll()
        {
            return dataContext.Clientes.ToList();
        }


        //Criando Metodo FindAll com Representante
        public IList<ClienteModel> FindAllWithRepresentante()
        {
            return dataContext.Clientes.Include(r => r.Representante).ToList();
        }


        // Criando Metodo FindById
        public ClienteModel? FindById(int id)
        {
            return dataContext.Clientes.Find(id);
        }

        // Criando Metodo FindById com Representante
        public ClienteModel? FindByIdWithRepresentante(int id)
        {
            return dataContext.Clientes.Include(r => r.Representante).SingleOrDefault(c => c.ClienteId == id); // Esta funcao tambem gera um JOIN, porem o metodo Find nao funciona mais
        }


        //Criando Metodo Insert
        public int Insert(ClienteModel clienteModel)
        {
            dataContext.Clientes.Add(clienteModel);
            dataContext.SaveChanges();

            return clienteModel.ClienteId;

        }
    }
}
