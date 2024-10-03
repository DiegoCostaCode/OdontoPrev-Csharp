using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly BancoContext _bancoContext;
        public EnderecoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public EnderecoModel Adicionar(EnderecoModel endereco)
        {
            _bancoContext.CH_ENDERECO.Add(endereco);
            _bancoContext.SaveChanges();
            return endereco;
        }
    }
}
