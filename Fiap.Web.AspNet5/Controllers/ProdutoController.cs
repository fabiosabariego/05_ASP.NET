using AutoMapper;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Intrinsics.X86;

namespace Fiap.Web.AspNet5.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository produtoRepository;
        private readonly ILojaRepository lojaRepository;
        private readonly IMapper mapper;

        public ProdutoController(IProdutoRepository _produtoRepository, ILojaRepository _lojaRepository, IMapper _mapper)
        {
            this.produtoRepository = _produtoRepository;
            this.lojaRepository = _lojaRepository;
            this.mapper = _mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Novo()
        {
            var vm = new ProdutoNovoViewModel();
            vm.Lojas = LoadLojas();
            return View(vm);
        }


        [HttpPost]
        public IActionResult Novo(ProdutoNovoViewModel produtoNovoViewModel)
        {
            var produtoModel = new ProdutoModel();
            produtoModel.ProdutoNome = produtoNovoViewModel.ProdutoNome;
            produtoModel.ProdutosLojas = new List<ProdutoLojaModel>();

            if(produtoNovoViewModel.LojaId != null || produtoNovoViewModel.LojaId.Count > 0)
            {
                foreach (var item in produtoNovoViewModel.LojaId)
                {
                    var produtoLojaModel = new ProdutoLojaModel();
                    produtoLojaModel.LojaId = item;
                    produtoLojaModel.Produto = produtoModel;

                    produtoModel.ProdutosLojas.Add(produtoLojaModel);
                }
            }

            produtoRepository.Insert(produtoModel);

            return View(produtoNovoViewModel);
        }

        private SelectList LoadLojas()
        {
            var listaLojas = lojaRepository.FindAll();
            var listaLojasVM = mapper.Map<List<LojaViewModel>>(listaLojas);

            var lojasSelectList = new SelectList(listaLojasVM, "LojaId", "LojaNome");

            return lojasSelectList;
        }
    }
}
