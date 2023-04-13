using WebApiConsulta.Repository.Model;

namespace WebApiConsulta.Repositorie.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
    }
}
