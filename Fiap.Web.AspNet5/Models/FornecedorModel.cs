using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{

    [Table("FORNECEDOR")] // Aqui fazemos uma relação da tabela existente (por exemplo) com a nossa, ou para criar uma tabela atribuirá esse nome

    public class FornecedorModel    //[] é usado para colocar o nome da tabela, caso não tenha será criada a tabela como FornecedorModel
    {
        [Key]                       // Por padrão, quando criado como Id ele já define, porém podemos com esta condição colocar como primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //Define o Id como auto incremento
        public int FornecedorId { get; set; }

        [StringLength(70)]
        [Column("Nome")]
        public string? FornecedorNome { get; set; }

        [StringLength(14)]
        public string? Cnpj { get; set; }

        [StringLength(11)]
        public string? Telefone { get; set; }

        [StringLength(90)]
        public string? Email { get; set; }

        public FornecedorModel()
        {

        }

        public FornecedorModel(int fornecedorId, string? fornecedorNome, string? cnpj, string? telefone, string? email)
        {
            FornecedorId = fornecedorId;
            FornecedorNome = fornecedorNome;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
        }
    }
}
