using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{

    [Table("Loja")]
    public class LojaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LojaId { get; set; }

        [Required]
        [StringLength(50)]
        public string LojaNome { get; set; }

        public ICollection<ProdutoLojaModel> ProdutosLojas { get; set; }        // Navigation Property

    }
}
