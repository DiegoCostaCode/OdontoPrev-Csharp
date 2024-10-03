namespace WebApp.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }

        public string TELEFONE { get; set; }

        public DateOnly NASCIMETNO { get; set; }

        public string EMAIL { get; set; }

        public EnderecoModel ENDERECO_ID { get; set; }
    }
}
