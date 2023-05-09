using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.AspNet5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DataContext dataContext;


        public HomeController(ILogger<HomeController> logger, DataContext ctx)
        {
            _logger = logger;
            dataContext = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //var lista = dataContext.Fornecedores.ToList();
            //var fornecedores = dataContext.Fornecedores.Find(2);


            //-----------------------------------------------------------
            /*
            FornecedorModel f1 = new FornecedorModel();
            f1.Telefone = "444999444";
            f1.Email = "suport@assus.com";
            f1.FornecedorNome = "Assus";
            f1.Cnpj = "494";

            dataContext.Fornecedores.Add(f1);

            FornecedorModel f2 = new FornecedorModel();
            f2.Telefone = "55599555";
            f2.Email = "suport@lg.com";
            f2.FornecedorNome = "LG";
            f2.Cnpj = "695";

            dataContext.Fornecedores.Add(f2);
            dataContext.SaveChanges();
            */
            //-----------------------------------------------------------


            //-----------------------------------------------------------
            /*
            FornecedorModel f2 = new FornecedorModel();
            f2.Telefone = "55599555";
            f2.Email = "suport@lge.com";
            f2.FornecedorNome = "LGE";
            f2.Cnpj = "695";

            dataContext.Fornecedores.Update(f2);
            dataContext.SaveChanges();
            */
            //-----------------------------------------------------------


            //-----------------------------------------------------------
            /*
            FornecedorModel model = new FornecedorModel();
            model.FornecedorId = 8;
            dataContext.Fornecedores.Remove(model);
            dataContext.SaveChanges();
            */
            //-----------------------------------------------------------


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}