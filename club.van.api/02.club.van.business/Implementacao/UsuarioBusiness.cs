using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.UsuarioArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Implementacao
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private IUsuarioDao usuarioDao;

        private IEmpresaDao empresaDao;

        private IPerfilDao perfilDao;

        private IRotaDao rotaDao;

        public UsuarioBusiness(IUsuarioDao usuarioDao, IEmpresaDao empresaDao, IPerfilDao perfilDao, IRotaDao rotaDao)
        {
            this.usuarioDao = usuarioDao;

            this.empresaDao = empresaDao;

            this.perfilDao = perfilDao;

            this.rotaDao = rotaDao;
        }

        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest adicionarUsuarioRequest)
        {
            if (this.ValidarUsuario(adicionarUsuarioRequest))
            {
                var perfil = this.perfilDao.Obter(adicionarUsuarioRequest.PerfilId);
                if (perfil == null)
<<<<<<< HEAD
                    throw new Exception("Nenhum perfil econtrado com esse id");

                var empresa = this.empresaDao.Obter(adicionarUsuarioRequest.EmpresaId);
                if (empresa == null)
                    throw new Exception("Nenhuma empresa econtrada com esse id");

                var rota = this.rotaDao.Obter(adicionarUsuarioRequest.RotaId);
                if (rota == null)
                    throw new Exception("Nenhuma rota econtrada com esse id");
=======
                    throw new Exception("");

                var empresa = this.empresaDao.Obter(adicionarUsuarioRequest.EmpresaId);
                if (empresa == null)
                    throw new Exception("");

                var rota = this.rotaDao.Obter(adicionarUsuarioRequest.RotaId);
                if (rota == null)
                    throw new Exception("");
>>>>>>> e1a2c6e1549b6a85ff7d89362636d37fe6178cda

                var usuario = new Usuario();
                {
                    usuario.Nome = adicionarUsuarioRequest.Nome;
                    usuario.Cpf = adicionarUsuarioRequest.Cpf;
                    usuario.Email = adicionarUsuarioRequest.Email;
                    usuario.Senha = adicionarUsuarioRequest.Senha;
                    usuario.Perfil = perfil;
                    usuario.Ativo = true;
                    usuario.Empresa = empresa;
                    usuario.Bairro = adicionarUsuarioRequest.Bairro;
                    usuario.Rua = adicionarUsuarioRequest.Rua;
                    usuario.Cidade = adicionarUsuarioRequest.Cidade;
                    usuario.Uf = adicionarUsuarioRequest.Uf;
                    usuario.Rota = rota;
                }

                this.usuarioDao.Salvar(usuario);

                return new AdicionarUsuarioResponse(usuario.Id);
            }

<<<<<<< HEAD
            throw new Exception("Não foi possivel adicionar o usuário");
=======
            return null;
>>>>>>> e1a2c6e1549b6a85ff7d89362636d37fe6178cda
        }

        public bool AutenticarUsuario(string email, string senha)
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

            if (AdicionarUsuarioRequest.PerfilId == null)
                throw new Exception("Nome não pode ser vazio");

            if (AdicionarUsuarioRequest.EmpresaId == null)
                throw new Exception("Empresa não pode ser vazia");

            if (AdicionarUsuarioRequest.Bairro == null)
                throw new Exception("Bairro não pode ser vazio");

            if (AdicionarUsuarioRequest.Rua == null)
                throw new Exception("Rua não pode ser vazia");

            if (AdicionarUsuarioRequest.Cidade == null)
                throw new Exception("Cidade não pode ser vazia");

            if (AdicionarUsuarioRequest.Uf == null)
                throw new Exception("UF não pode ser vazia");

            if (AdicionarUsuarioRequest.RotaId == null)
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
                return sb.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AtualizarUsuarioResponse Update(AtualizarUsuarioRequest atualizarUsuarioRequest)
        {
            if (atualizarUsuarioRequest.Id == null)
                throw new Exception("O id não pode estar vazio");

            Usuario usuario = new Usuario();
            {
                usuario.Nome = atualizarUsuarioRequest.Nome;
                usuario.Cpf = atualizarUsuarioRequest.Cpf;
                usuario.Email = atualizarUsuarioRequest.Email;
                usuario.Senha = atualizarUsuarioRequest.Senha;
                usuario.Perfil.Id = atualizarUsuarioRequest.PerfilId;
                usuario.Ativo = atualizarUsuarioRequest.Ativo;
                usuario.Empresa.Id = atualizarUsuarioRequest.EmpresaId;
                usuario.Bairro = atualizarUsuarioRequest.Bairro;
                usuario.Rua = atualizarUsuarioRequest.Rua;
                usuario.Cidade = atualizarUsuarioRequest.Cidade;
                usuario.Uf = atualizarUsuarioRequest.Uf;
                usuario.Rota.Id = atualizarUsuarioRequest.RotaId;
            }

            this.usuarioDao.Salvar(usuario);

            return new AtualizarUsuarioResponse(usuario);
        }

        public void Delete(Guid id)
        {
            var response = this.usuarioDao.Obter(id);

            if (response == null)
                throw new Exception("O usuario informado não existe");

            this.usuarioDao.Delete(response);
        }

        public List<Usuario> ObterTodos()
        {
            return this.usuarioDao.ObterTodos();
        }
    }
}

