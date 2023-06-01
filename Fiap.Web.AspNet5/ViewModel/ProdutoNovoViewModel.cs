using Fiap.Web.AspNet5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class ProdutoNovoViewModel
    {
        [Required]
        public string ProdutoNome { get; set; }

        public SelectList Lojas { get; set; }

        [Required]
        public ICollection<int> LojaId { get; set; }

    }
}
