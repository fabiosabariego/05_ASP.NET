using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class ClientePesquisaViewModel
    {
        [Display(Name = "Digite Parte do Nome:")]
        public string ClienteNome { get; set; }

        [Display(Name = "Digite parde to Email")]
        public string ClienteEmail { get; set; }

        public int RepresentanteId { get; set; }

        [Display(Name = "Selecione um Representante")]
        public SelectList Representantes { get; set; }

        public IList<ClienteViewModel> Clientes { get; set; }
    }
}
