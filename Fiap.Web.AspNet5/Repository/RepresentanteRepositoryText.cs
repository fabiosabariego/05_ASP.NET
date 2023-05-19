using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;

namespace Fiap.Web.AspNet5.Repository
{
    public class RepresentanteRepositoryText : IRepresentanteRepository
    {
        private readonly DataContext dataContext;

        public RepresentanteRepositoryText(DataContext context)
        {
            dataContext = context;
        }

        public List<RepresentanteModel> FindAll()
        {
            return dataContext.Representantes
                    .OrderBy(r => r.RepresentanteId)
                        .ToList<RepresentanteModel>();
        }

        public RepresentanteModel FindById(int id)
        {
            return dataContext.Representantes.Find(id);
        }

        public void Insert(RepresentanteModel representanteModel)
        {
            dataContext.Representantes.Add(representanteModel);
            dataContext.SaveChanges();
        }

        public void Update(RepresentanteModel representanteModel)
        {
            dataContext.Representantes.Update(representanteModel);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            RepresentanteModel representante = new RepresentanteModel();
            representante.RepresentanteId = id;
            Delete(representante);
        }

        public void Delete(RepresentanteModel representanteModel)
        {
            dataContext.Representantes.Remove(representanteModel);
            dataContext.SaveChanges();
        }

        IList<RepresentanteModel> IRepresentanteRepository.FindAll()
        {
            throw new NotImplementedException();
        }

        int IRepresentanteRepository.Insert(RepresentanteModel representanteModel)
        {
            throw new NotImplementedException();
        }
    }
}