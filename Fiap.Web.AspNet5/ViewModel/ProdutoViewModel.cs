using Fiap.Web.AspNet5.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }

        public string ProdutoNome { get; set; }

    }
}
