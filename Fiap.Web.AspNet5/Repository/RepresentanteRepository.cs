using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;

namespace Fiap.Web.AspNet5.Repository
{
    public class RepresentanteRepository
    {
        //      CRUD
        // Find By Id (Read)
        // Find All (Read)
        // Insert (Create)
        // Update
        // Delete

        //-------------------------------------------------
        //Criando acesso ao Data Context
        private readonly DataContext _dataContext;

        public RepresentanteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        //-------------------------------------------------

        //Criando Metodo FindAll
        public IList<RepresentanteModel> FindAll()
        {
            return _dataContext.Representantes.ToList();
        }

        //Criando Metodo Find By Id
        public RepresentanteModel? FindById(int id)
        {
            return _dataContext.Representantes.Find(id);
        }

        //Criando Metodo para Criar Fornecedores (Insert)
        public int Insert(RepresentanteModel representanteModel)
        {
            _dataContext.Representantes.Add(representanteModel);
            _dataContext.SaveChanges();

            return representanteModel.RepresentanteId;
        }

        //Criando Metodo para Update
        public void Update(RepresentanteModel representanteModel)
        {
            _dataContext.Representantes.Update(representanteModel);
            _dataContext.SaveChanges();
        }


        //Criando o Metodo Delete passando toda estrutura do model
        public void Delete(RepresentanteModel representanteModel)
        {
            _dataContext.Representantes.Remove(representanteModel);
            _dataContext.SaveChanges();
        }

        //Criando o Metodo Delete (Passando o ID)
        public void Delete(int id)
        {
            var representanteModel = new RepresentanteModel()
            {
                RepresentanteId = id
            };

            Delete(representanteModel);
        }


    }
}
