using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.UsuarioArguments;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

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
            var perfil = perfilDao.Obter(adicionarUsuarioRequest.PerfilId)
                ?? throw new Exception("Nenhum perfil encontrado com esse id");

            var empresa = empresaDao.Obter(adicionarUsuarioRequest.EmpresaId)
                ?? throw new Exception("Nenhuma empresa encontrada com esse id");

            var rota = rotaDao.Obter(adicionarUsuarioRequest.RotaId)
                ?? throw new Exception("Nenhuma rota encontrada com esse id");

            var usuario = new Usuario
            {
                Nome = adicionarUsuarioRequest.Nome,
                Cpf = adicionarUsuarioRequest.Cpf,
                Email = adicionarUsuarioRequest.Email,
                Senha = CalculateHash(adicionarUsuarioRequest.Senha),
                Perfil = perfil,
                Ativo = true,
                Empresa = empresa,
                Bairro = adicionarUsuarioRequest.Bairro,
                Rua = adicionarUsuarioRequest.Rua,
                Cidade = adicionarUsuarioRequest.Cidade,
                Uf = adicionarUsuarioRequest.Uf,
                Rota = rota,
            };

            if (!ValidarUsuario(adicionarUsuarioRequest))
            {
                throw new Exception("Não foi possível adicionar o usuário");
            }

            usuarioDao.Salvar(usuario);

            return new AdicionarUsuarioResponse(usuario.Id);
        }

        public Usuario AutenticarUsuario(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                return null;

            var senhaHash = CalculateHash(senha);

            var response = this.usuarioDao.Obter(email, senhaHash);

            return response?.Id != null ? response : null;
        }


        private bool ValidarUsuario(AdicionarUsuarioRequest request)
        {
            var errorMessage = new StringBuilder();
            if (string.IsNullOrEmpty(request.Nome))
                errorMessage.AppendLine("Nome não pode ser vazio");
            if (string.IsNullOrEmpty(request.Cpf))
                errorMessage.AppendLine("Cpf não pode ser vazio");
            if (string.IsNullOrEmpty(request.Email))
                errorMessage.AppendLine("Email não pode ser vazio");
            if (string.IsNullOrEmpty(request.Senha))
                errorMessage.AppendLine("Senha não pode ser vazia");
            if (request.PerfilId == null)
                errorMessage.AppendLine("Nome não pode ser vazio");
            if (request.EmpresaId == null)
                errorMessage.AppendLine("Empresa não pode ser vazia");
            if (string.IsNullOrEmpty(request.Bairro))
                errorMessage.AppendLine("Bairro não pode ser vazio");
            if (string.IsNullOrEmpty(request.Rua))
                errorMessage.AppendLine("Rua não pode ser vazia");
            if (string.IsNullOrEmpty(request.Cidade))
                errorMessage.AppendLine("Cidade não pode ser vazia");
            if (string.IsNullOrEmpty(request.Uf))
                errorMessage.AppendLine("UF não pode ser vazia");
            if (request.RotaId == null)
                errorMessage.AppendLine("Rota não pode ser vazia");

            if (errorMessage.Length > 0)
                throw new ArgumentNullException(errorMessage.ToString());

            return true;
        }


        public string CalculateHash(string senha)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new System.Text.StringBuilder();
            foreach (var h in hash)
            {
                sb.Append(h.ToString("X2"));
            }
            return sb.ToString();
        }

        public AtualizarUsuarioResponse Update(AtualizarUsuarioRequest atualizarUsuarioRequest)
        {
            if (atualizarUsuarioRequest.Id == Guid.Empty)
            {
                throw new ArgumentException("O id não pode estar vazio", nameof(atualizarUsuarioRequest));
            }

            var perfil = perfilDao.Obter(atualizarUsuarioRequest.PerfilId)
                ?? throw new ArgumentException("Nenhum perfil encontrado com esse id", nameof(atualizarUsuarioRequest));

            var rota = rotaDao.Obter(atualizarUsuarioRequest.RotaId)
                ?? throw new ArgumentException("Nenhuma rota encontrada com esse id", nameof(atualizarUsuarioRequest));

            var usuario = usuarioDao.Obter(atualizarUsuarioRequest.Id)
                ?? throw new ArgumentException("Nenhuma usuário encontrado com esse id", nameof(atualizarUsuarioRequest));

            usuario.Nome = atualizarUsuarioRequest.Nome;
            usuario.Cpf = atualizarUsuarioRequest.Cpf;
            usuario.Email = atualizarUsuarioRequest.Email;
            usuario.Perfil = perfil;
            usuario.Bairro = atualizarUsuarioRequest.Bairro;
            usuario.Rua = atualizarUsuarioRequest.Rua;
            usuario.Cidade = atualizarUsuarioRequest.Cidade;
            usuario.Uf = atualizarUsuarioRequest.Uf;
            usuario.Rota = rota;

            usuarioDao.Atualizar(usuario);

            return new AtualizarUsuarioResponse(usuario);
        }

        public void Delete(Guid id)
        {
            var usuario = usuarioDao.Obter(id) ?? throw new ArgumentException("O usuário informado não existe", nameof(id));
            usuarioDao.Delete(usuario);
        }

        public List<Usuario> ObterTodos()
        {
            return usuarioDao.ObterTodos();
        }

        public ResetUsuarioResponse ResetUserPassword(ResetUsuarioRequest resetUsuarioRequest)
        {
            var usuario = usuarioDao.FindByEmail(resetUsuarioRequest.Email)
                ?? throw new ArgumentException("O usuário informado não existe", nameof(resetUsuarioRequest));

            var senha = GerarSenha();

            usuario.Senha = CalculateHash(senha);

            usuarioDao.Atualizar(usuario);

            EnviarEmail(senha, resetUsuarioRequest.Email);

            return new ResetUsuarioResponse(usuario.Id);
        }

        public string GerarSenha()
        {
            var senha = 0;
            var rd = new Random();

            for (var i = 0; i < 4; i++)
            {
                senha += rd.Next();
            }

            return senha.ToString();
        }

        public void EnviarEmail(string senha, string email)
        {
            try
            {
                using var mySmtpClient = new SmtpClient("smtp.gmail.com", 587);
                mySmtpClient.Credentials = new NetworkCredential("robertomaier02@gmail.com", "");
                mySmtpClient.EnableSsl = true;

                var from = new MailAddress("robertomaier02@gmail.com", "Club Van");
                var to = new MailAddress(email, email);

                using var myMail = new MailMessage(from, to)
                {
                    Subject = "Sua senha foi redefinida",
                    SubjectEncoding = Encoding.UTF8,
                    Body = $"Sua senha foi redefinida, agora você pode usar essa senha para logar no sistema: {senha}",
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = true
                };

                mySmtpClient.Send(myMail);
            }
            catch (SmtpException ex)
            {
                throw new ApplicationException($"SmtpException has occured: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Usuario GetUserById(Guid id)
        {
            return this.usuarioDao.Obter(id);
        }
    }
}

