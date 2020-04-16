using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.UsuarioArguments;
using System;

namespace club.van.api.business.Implementacao
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private IUsuarioDao usuarioDao;

        public UsuarioBusiness(IUsuarioDao usuarioDao)
        {
            this.usuarioDao = usuarioDao;
        }

        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest adicionarUsuarioRequest)
        {
            try
            {
                if (this.ValidarUsuario(adicionarUsuarioRequest))
                {
                    Usuario usuario = new Usuario();
                    {
                        usuario.Nome = adicionarUsuarioRequest.Nome;
                        usuario.Cpf = adicionarUsuarioRequest.Cpf;
                        usuario.Email = adicionarUsuarioRequest.Email;
                        usuario.Senha = adicionarUsuarioRequest.Senha;
                        usuario.Perfil = adicionarUsuarioRequest.Perfil;
                        usuario.Ativo = true;
                        usuario.Empresa = adicionarUsuarioRequest.Empresa;
                        usuario.Bairro = adicionarUsuarioRequest.Bairro;
                        usuario.Rua = adicionarUsuarioRequest.Rua;
                        usuario.Cidade = adicionarUsuarioRequest.Cidade;
                        usuario.Uf = adicionarUsuarioRequest.Uf;
                        usuario.Rota = adicionarUsuarioRequest.Rota;
                    }
                }

                return null; // apenas para teste
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AutenticarUusuario(string email, string senha)
        {
            var senhaHash = this.CalculaHash(senha);

            var response = this.usuarioDao.Obter(email, senhaHash);

            if (response == null)
                throw new Exception("Nenhum usuario encontrado");
            else
                return true;
        }

        private bool ValidarUsuario(AdicionarUsuarioRequest AdicionarUsuarioRequest)
        {
            if (AdicionarUsuarioRequest.Nome == null)
                throw new Exception("Nome não pode ser vazio");

            if (AdicionarUsuarioRequest.Cpf == null)
                throw new Exception("Cpf não pode ser vazio");

            if (AdicionarUsuarioRequest.Email == null)
                throw new Exception("Email não pode ser vazio");

            if (AdicionarUsuarioRequest.Senha == null)
                throw new Exception("Senha não pode ser vazia");

            if (AdicionarUsuarioRequest.Perfil == null)
                throw new Exception("Nome não pode ser vazio");

            if (AdicionarUsuarioRequest.Empresa == null)
                throw new Exception("Empresa não pode ser vazia");

            if (AdicionarUsuarioRequest.Bairro == null)
                throw new Exception("Bairro não pode ser vazio");

            if (AdicionarUsuarioRequest.Rua == null)
                throw new Exception("Rua não pode ser vazia");

            if (AdicionarUsuarioRequest.Cidade == null)
                throw new Exception("Cidade não pode ser vazia");

            if (AdicionarUsuarioRequest.Uf == null)
                throw new Exception("UF não pode ser vazia");

            if (AdicionarUsuarioRequest.Rota == null)
                throw new Exception("Rota não pode ser vazia");

            else
                return true;
        }

        public string CalculaHash(string Senha)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString(); // Retorna senha criptografada 
            }
            catch (Exception)
            {
                return null; // Caso encontre erro retorna nulo
            }
        }

    }
}

