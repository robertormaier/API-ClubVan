namespace club.van.api.data.dto.UsuarioArguments
{
    public class AdicionarUsuarioConfiguracoesRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public string Endereco { get; set; }
    }
}
