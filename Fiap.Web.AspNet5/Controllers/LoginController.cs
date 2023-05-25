using AutoMapper;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Fiap.Web.AspNet5.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository usuariosRepository;
        private readonly IMapper mapper;

        public LoginController(IUsuarioRepository _usuariosRepository, IMapper _mapper)
        {
            this.usuariosRepository = _usuariosRepository;
            this.mapper = _mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                /*
                var usuario = new UsuarioModel();
                usuario.UsuarioSenha = loginViewModel.UsuarioSenha;
                usuario.UsuarioEmail = loginViewModel.UsuarioEmail;
                */

                var usuario = mapper.Map<UsuarioModel>(loginViewModel);
                var usuarioLogado = usuariosRepository.Login(usuario);

                if (usuarioLogado == null || usuarioLogado.UsuarioId == 0)
                {
                    ViewBag.ErrorMessage = "Login ou Senha invalida!";
                    return View(nameof(Index));
                }
                else
                {
                   
                    loginViewModel = mapper.Map<LoginViewModel>(usuarioLogado);

                    var vmJson = Newtonsoft.Json.JsonConvert.SerializeObject(loginViewModel);
                    HttpContext.Session.SetString("usuarioLogado", vmJson);
                    return RedirectToAction(nameof(Index), "Home");
                    
                }

            }
            else
            {
                return View(nameof(Index));
            }

        }

        [HttpGet]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
