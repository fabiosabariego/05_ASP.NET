using Fiap.Web.AspNet5.Models;

namespace Fiap.Web.AspNet5.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public UsuarioModel Login(UsuarioModel usuarioModel);
    }
}
