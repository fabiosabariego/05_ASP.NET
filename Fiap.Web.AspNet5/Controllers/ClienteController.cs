using Fiap.Web.AspNet5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet5.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var listaClientes = new List<ClienteModel>();
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 1,
                Nome = "Flávio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 2,
                Nome = "Eduardo",
                Email = "eduardo@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 4,
                Nome = "Luan",
                Email = "luan@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS4"
            });

            return View(listaClientes);
            
        }


        [HttpGet]       //Consumir, abrir coisas
        public IActionResult Novo()
        {

            return View(new ClienteModel());

        }


        [HttpPost]      //Trabalhamos como submit, ou enviando alguma coisa para o servidor (ou banco)
        public IActionResult Novo(ClienteModel clienteModel)
        {

             if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O Campo Nome deve ser preenchido!";
                return View(clienteModel);
            }
            else
            {
                TempData["Mensagem"] = $"Cliente {clienteModel.Nome} {clienteModel.Sobrenome} cadastrado com Sucesso!!";
                return RedirectToAction("Index", "Cliente");
            }
            
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            
            var clienteModel = new ClienteModel
            {   
                ClienteId = 1,
                Nome = "Flávio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1" 
            };

            return View(clienteModel);
;        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {

            if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O nome do cliente é obrigatório!";

                return View(clienteModel);
            }
            else
            {
                TempData["Mensagem"] = $"O cliente {clienteModel.Nome} foi alterado com sucesso";
                return RedirectToAction("Index", "Cliente");
                //ViewBag.Cliente = clienteModel;  -> Nao Funciona quando utilizamos o RedirectToAction
            }

            //"UPDATE tabelaClientes SET Nome = {clienteModel.Nome} .... WHERE id = {clienteModel.ClienteId}";

        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {
           var clienteModel = new ClienteModel
            {
                ClienteId = 1,
                Nome = "Flavio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1"
            };

            return View(clienteModel);
        }

        [HttpPost]
        public IActionResult Detalhe(ClienteModel clienteModel)
        {
            return View("Index");
        }


        [HttpGet]
        public IActionResult Remover(int id)
        {
            //"DELETE FROM tabelaCliente WHERE id = {id}";

            TempData["Mensagem"] = $"O cliente foi removido com sucesso!";
            return RedirectToAction("Index", "Cliente");
        }

    }
}
