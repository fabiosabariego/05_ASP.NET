using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Repository
{
    public class ClienteRepository : IClienteRepository
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

        public IList<ClienteModel> FindAllOrderByNome()
        {
            var lista = dataContext
                .Clientes                               // SELECT * FROM Clientes
                .Include(r => r.Representante)          // INNER JOIN
                .OrderBy(c => c.Nome)                   // Condicao para ordenar
                .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
        }

        public IList<ClienteModel> FindAllOrderByNomeDesc()
        {
            var lista = dataContext
                .Clientes                               // SELECT * FROM Clientes
                .Include(r => r.Representante)          // INNER JOIN
                .OrderByDescending(c => c.Nome)         // Condicao para ordenar
                .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
        }

        public IList<ClienteModel> FindByNome(string nome)
        {
            var lista = dataContext
                .Clientes                                                   // SELECT * FROM Clientes
                .Include(r => r.Representante)                              // INNER JOIN
                .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))      // WHERE    -> Contains == LIKE
                .OrderBy(c => c.Nome)                                       // ORDERBY
                .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
        }

        public IList<ClienteModel> FindByNomeAndEmail(string nome, string email)
        {
            var lista = dataContext
                .Clientes                                                   // SELECT * FROM Clientes
                .Include(r => r.Representante)                              // INNER JOIN
                .Where
                    (c => c.Nome.ToLower().Contains(nome.ToLower()) &&
                     c.Email.ToLower().Contains(email.ToLower())
                    )                                                       // WHERE    -> Contains == LIKE
                .OrderBy(c => c.Nome)                                       // ORDERBY
                .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
        }

        public IList<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int repId)
        {
            var lista = dataContext
                .Clientes                                                   // SELECT * FROM Clientes
                .Include(r => r.Representante)                              // INNER JOIN
                .Where
                    (
                        c => ( string.IsNullOrEmpty(nome)   || c.Nome.ToLower().Contains(nome.ToLower()) ) &&
                             ( string.IsNullOrEmpty(email)  || c.Email.ToLower().Contains(email.ToLower()) ) &&
                             ( repId == 0                   || c.RepresentanteId == repId)
                    )                                                       // WHERE    -> Contains == LIKE
                .OrderBy(c => c.Nome)                                       // ORDERBY
                .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
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

        // Criando Metodo Update
        public void Update(ClienteModel clienteModel)
        {
            dataContext.Clientes.Update(clienteModel);
            dataContext.SaveChanges();
        }
    }
}
