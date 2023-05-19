using Fiap.Web.AspNet5.Models;

namespace Fiap.Web.AspNet5.Repository.Interface
{
    public interface IFornecedorRepository
    {
        public IList<FornecedorModel> FindAll();
        public FornecedorModel? FindById(int id);
        public int Insert(FornecedorModel fornecedorModel);
        public void Update(FornecedorModel fornecedorModel);
        public void Delete(FornecedorModel fornecedorModel);
        public void Delete(int id);

    }
}
