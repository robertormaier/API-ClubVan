using System;

namespace club.van.api.data.dto.UsuarioArguments
{
    public class AtualizarUsuarioResponse
    {
        public AtualizarUsuarioResponse(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Cpf = usuario.Cpf;
            Email = usuario.Email;
            Perfil = usuario.Perfil;
            Ativo = usuario.Ativo;
            Senha = usuario.Senha;
            Empresa = usuario.Empresa;
            Bairro = usuario.Bairro;
            Rua = usuario.Rua;
            Cidade = usuario.Cidade;
            Uf = usuario.Uf;
            Rota = usuario.Rota;
        }

        public Guid Id { get; set; }
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
    }
}
