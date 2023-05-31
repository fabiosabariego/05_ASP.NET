using Fiap.Web.AspNet5.Models;

namespace Fiap.Web.AspNet5.Repository.Interface
{
    public interface ILojaRepository
    {
        public IList<LojaModel> FindAll();
        public LojaModel? FindById(int id);
    }
}
