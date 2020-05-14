using club.van.api.data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace club.van.api.data
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }
        public Empresa Empresa { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public Rota Rota { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
