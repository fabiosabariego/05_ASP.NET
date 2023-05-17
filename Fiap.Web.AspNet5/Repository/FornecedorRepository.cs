using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using System.Drawing;

namespace Fiap.Web.AspNet5.Repository
{
    public class FornecedorRepository :IFornecedorRepository       //Classe do tipo Repository usada para conexão com o Banco de Dados
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

        public FornecedorRepository(DataContext ctx)
        {
            this.dataContext = ctx;
        }
        //-------------------------------------------------


        //Criando Metodo FindAll
        public IList<FornecedorModel> FindAll()
        {
            return dataContext.Fornecedores.ToList();
        }


        //Criando Metodo FindById
        public FornecedorModel? FindById(int id)
        {
            return dataContext.Fornecedores.Find(id);
        }


        //Criando Metodo Insert
        public int Insert(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Add(fornecedorModel);
            dataContext.SaveChanges();

            return fornecedorModel.FornecedorId; 

        }

        //Criando Metodo Update
        public void Update(FornecedorModel fornecedorModel)
        {

            dataContext.Fornecedores.Update(fornecedorModel);
            dataContext.SaveChanges();

        }

        //Criando Metodo Delete
        public void Delete(FornecedorModel fornecedorModel)
        {

            dataContext.Fornecedores.Remove(fornecedorModel);
            dataContext.SaveChanges();

        }

        //Criando Metodo Delete
        public void Delete(int id)
        {
            var model = new FornecedorModel()
            {
                FornecedorId = id
            };

            Delete(model);
        }
    }
}
