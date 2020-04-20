using System;

namespace club.van.api.data.dto.UsuarioArguments
{
    public class AdicionarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Guid PerfilId { get; set; }
        public string Senha { get; set; }
        public Guid EmpresaId { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public Guid RotaId { get; set; }
    }
}
