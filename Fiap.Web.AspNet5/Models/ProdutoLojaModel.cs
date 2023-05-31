using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{
    [Table("ProdutoLoja")]
    [Index(nameof(ProdutoId), nameof(LojaId), IsUnique = false)]        // Feito para que nao sejam repetidos
    public class ProdutoLojaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoLojaId { get; set; }  // Primary Key



        public int ProdutoId { get; set; }      // Foreign Key Produto

        [ForeignKey(nameof(ProdutoId))]
        public ProdutoModel Produto { get; set; }   // Navigation Property



        public int LojaId { get; set; }         // Foreign Key Loja

        [ForeignKey(nameof(LojaId))]
        public LojaModel Loja { get; set; }     // Navigation Property
    }
}
