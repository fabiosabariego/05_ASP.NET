using Fiap.Web.AspNet5.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class ProdutoLojaViewModel
    {
        public int ProdutoLojaId { get; set; }  // Primary Key

        public int ProdutoId { get; set; }      // Foreign Key Produto

        public ProdutoViewModel Produto { get; set; }   // Navigation Property

        public int LojaId { get; set; }         // Foreign Key Loja

        public LojaViewModel Loja { get; set; }     // Navigation Property
    }
}
