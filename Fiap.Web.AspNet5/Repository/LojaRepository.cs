using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly DataContext dataContext;

        public LojaRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IList<LojaModel> FindAll()
        {

            var lojas = dataContext.Lojas
                .Include(l => l.ProdutosLojas)
                    .ThenInclude(p => p.Produto)
                        .ToList();

            return lojas;
        }

        public LojaModel? FindById(int id)
        {
            var lojas = dataContext.Lojas
                .Include(l => l.ProdutosLojas)
                    .ThenInclude(p => p.Produto)
                        .SingleOrDefault(l => l.LojaId == id);

            return lojas;
        }
    }
}
