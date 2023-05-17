using Fiap.Web.AspNet5.Models;

namespace Fiap.Web.AspNet5.Repository.Interface
{
    public interface IRepresentanteRepository
    {
        public IList<RepresentanteModel> FindAll();
        public RepresentanteModel? FindById(int id);
        public int Insert(RepresentanteModel representanteModel);
        public void Update(RepresentanteModel representanteModel);
        public void Delete(RepresentanteModel representanteModel);
        public void Delete(int id);
    }
}
