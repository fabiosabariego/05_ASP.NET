using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{

    [Table("Clientes")]
    [Index(nameof(Nome), IsUnique = false)]

    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        // ForeignKey
        public int RepresentanteId { get; set; }

        [StringLength(50)]
        public string? Nome { get; set; }

        [StringLength(50)]
        public string? Sobrenome { get; set; }

        [StringLength(80)]        
        public string? Email { get; set; }
        
        public DateTime DataNascimento { get; set; }

        [StringLength(400)]
        public string? Observacao { get; set; }


        // Navigation Property
        [ForeignKey(nameof(RepresentanteId))]
        public RepresentanteModel? Representante { get; set; }

    }
}
