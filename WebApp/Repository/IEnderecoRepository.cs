using WebApp.Models;

namespace WebApp.Repository
{
    public interface IEnderecoRepository
    {
       EnderecoModel Adicionar(EnderecoModel endereco);
    }
}
