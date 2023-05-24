using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet5.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository usuariosRepository;

        public LoginController(IUsuarioRepository _usuariosRepository)
        {
            this.usuariosRepository = _usuariosRepository;
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
                var usuarioLogado = usuariosRepository.Login(loginViewModel.UsuarioEmail, loginViewModel.UsuarioSenha);

                if (usuarioLogado == null || usuarioLogado.UsuarioId == 0)
                {
                    return View(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index), "Home");
                }
                */

                return RedirectToAction(nameof(Index), "Home");

            }
            else
            {
                return View(nameof(Index));
            }
                
                        

        }
    }
}
