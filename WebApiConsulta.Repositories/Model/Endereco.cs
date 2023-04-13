namespace WebApiConsulta.Repository.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Id_Pessoa { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
    }
}
