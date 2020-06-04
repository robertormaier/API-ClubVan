using System;

namespace club.van.api.data.dto.UsuarioArguments
{
    public class AtualizarUsuarioRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int Numero { get; set; }
        public Guid PerfilId { get; set; }
        public bool Ativo { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public Guid RotaId { get; set; }
    }
}
