using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }

        public string TELEFONE { get; set; }

        public DateOnly NASCIMENTO { get; set; }

        public string EMAIL { get; set; }

        [ForeignKey("ENDERECO")]
        public int? ENDERECO_ID { get; set; }
        public virtual EnderecoModel ENDERECO { get; set; }
    }
}
