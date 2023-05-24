using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;

namespace Fiap.Web.AspNet5.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext ctx)
        {
            this.dataContext = ctx;
        }

        public UsuarioModel Login(UsuarioModel usuarioModel)
        {
            return dataContext.Usuarios.SingleOrDefault(u => u.UsuarioEmail == usuarioModel.UsuarioEmail && u.UsuarioSenha == usuarioModel.UsuarioSenha);

        }
    }
}
