using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IList<ProdutoModel> FindAll()
        {
            var prod = dataContext.Produtos
                .Include(p => p.ProdutosLojas) // inner join PRODUTO LOJA
                    .ThenInclude(l => l.Loja)
                        .ToList();

            return prod;
        }

        public ProdutoModel? FindById(int id)
        {
            var prod = dataContext.Produtos
                .Include(p => p.ProdutosLojas) // inner join PRODUTO LOJA
                    .ThenInclude(l => l.Loja)  // inner joing LOJA
                        .SingleOrDefault(p => p.ProdutoId == id);

            return prod;
        }
    }
}
