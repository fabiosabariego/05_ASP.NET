using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class LoginViewModel
    {
        [HiddenInput]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Email Obrigatorio!")]
        [MaxLength(70, ErrorMessage = "Tamanho maximo de 70 Caracteres")]
        [MinLength(3, ErrorMessage = "Tamanho Minimo de 3 Caracteres")]
        [Display(Name = "Email:")]
        [EmailAddress]
        public string? UsuarioEmail { get; set; }

        [Required(ErrorMessage = "Senha Obrigatoria!")]
        [Display(Name = "Senha:")]
        [MinLength(5, ErrorMessage = "Tamanho minimo de 5 Caracteres")]
        [DataType(DataType.Password)]
        public string? UsuarioSenha { get; set; }

    }
}
