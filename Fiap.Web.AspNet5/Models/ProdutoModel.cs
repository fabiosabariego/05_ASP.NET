using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{

    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProdutoNome { get; set; }

        public ICollection<ProdutoLojaModel> ProdutosLojas { get; set; }        // Navigation Property

    }
}
