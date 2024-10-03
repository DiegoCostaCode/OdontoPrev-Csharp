using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _bancoContext.CH_USUARIO.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
    }
}
