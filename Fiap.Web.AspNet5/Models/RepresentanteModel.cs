using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{
    [Table("REPRESENTANTE")]
    [Index(nameof(NomeRepresentante), IsUnique = true)]
    
    public class RepresentanteModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepresentanteId { get; set; }


        [Required]
        [StringLength(60)]
        public string? NomeRepresentante { get; set; }


        [NotMapped]                         // Esta anotação diz que esse campo não precisará criar na tabela do banco
        public string? Token { get; set; }


        public RepresentanteModel()
        {

        }


        public RepresentanteModel(int representanteId, string? nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }
    }
}
