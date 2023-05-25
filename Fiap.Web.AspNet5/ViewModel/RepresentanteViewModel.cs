using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class RepresentanteViewModel
    {
        [HiddenInput]
        public int RepresentanteId { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomeRepresentante { get; set; }

        public string? Token { get; set; }
    }
}
