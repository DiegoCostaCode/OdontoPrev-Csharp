using WebApp.Models;

namespace WebApp.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel Adicionar(UsuarioModel usuario);
    }
}
