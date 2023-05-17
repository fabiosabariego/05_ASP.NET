using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet5.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteRepository clienteRepository;
        private readonly RepresentanteRepository representanteRepository;

        public ClienteController(DataContext context)               // Criando o Construtor para receber o DataContext
        {
            clienteRepository = new ClienteRepository(context);
            representanteRepository = new RepresentanteRepository(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var lista = clienteRepository.FindByNomeAndEmailAndRepresentante("", "", 3);
            return View(clienteRepository.FindAllWithRepresentante());               // Desta Forma o Codigo fica mais enxuto
        }


        [HttpGet]       //Consumir, abrir coisas
        public IActionResult Novo()
        {

            ComboRepresentantes();
            return View(new ClienteModel());

        }


        [HttpPost]      //Trabalhamos como submit, ou enviando alguma coisa para o servidor (ou banco)
        public IActionResult Novo(ClienteModel clienteModel)
        {

             if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O Campo Nome deve ser preenchido!";

                ComboRepresentantes();                                                      // Coleta todos os representantes para popular o combobox
                return View(clienteModel);                                                  // Retorna para tela todos os dados preenchidos para visualizar
            }
            else
            {
                clienteRepository.Insert(clienteModel);

                TempData["Mensagem"] = $"Cliente {clienteModel.Nome} {clienteModel.Sobrenome} cadastrado com Sucesso!!";
                return RedirectToAction("Index", "Cliente");
            }
            
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ComboRepresentantes();
            return View(clienteRepository.FindById(id));
;        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {

            if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O nome do cliente é obrigatório!";
                ComboRepresentantes();
                return View(clienteModel);
            }
            else
            {
                clienteRepository.Update(clienteModel);
                TempData["Mensagem"] = $"O cliente {clienteModel.Nome} foi alterado com sucesso";
                return RedirectToAction("Index", "Cliente");
                //ViewBag.Cliente = clienteModel;  -> Nao Funciona quando utilizamos o RedirectToAction
            }

            //"UPDATE tabelaClientes SET Nome = {clienteModel.Nome} .... WHERE id = {clienteModel.ClienteId}";

        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {

            return View(clienteRepository.FindByIdWithRepresentante(id));
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

        private void ComboRepresentantes()
        {
            var listaRepresentante = representanteRepository.FindAll();
            var selectListaRepresentante = new SelectList(listaRepresentante, "RepresentanteId", "NomeRepresentante");
            ViewBag.Representantes = selectListaRepresentante;
        }

    }
}
