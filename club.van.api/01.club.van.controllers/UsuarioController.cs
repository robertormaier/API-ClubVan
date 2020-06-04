using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.data.dto.UsuarioArguments;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace club.van.api.controllers
{

    [Route("api/UsuarioController")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioBusiness usuarioBusiness;

        private ILogger<UsuarioController> logger;

        private IConfiguration config;


        public UsuarioController(IUsuarioBusiness usuarioBusiness, ILogger<UsuarioController> logger, IConfiguration Configuration)
        {
            this.usuarioBusiness = usuarioBusiness;

            this.logger = logger;

            this.config = Configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AutenticarUsuario")]
        public IActionResult AutenticarUsuario([FromBody] AutenticarUsuarioRequest autenticarUsuarioRequest)
        {
            try
            {
                var response = this.usuarioBusiness.AutenticarUsuario(autenticarUsuarioRequest.Email, autenticarUsuarioRequest.Password);

                if (response != null)
                {
                    response.Token = this.GerarToken(autenticarUsuarioRequest.Email);
                    return base.Ok(response);
                }
                return base.NotFound("Nenhum usuário encontrado");
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return base.BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetAll/{empresaId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ObterTodos()
        {
            try
            {
                var response = this.usuarioBusiness.ObterTodos();
                return base.Ok(response);
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                var response = this.usuarioBusiness.GetUserById(id);
                return base.Ok(response);
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("Adicionar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Adicionar([FromBody] AdicionarUsuarioRequest adicionarUsuarioRequest)
        {

            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.usuarioBusiness.AdicionarUsuario(adicionarUsuarioRequest);
                        dbContextTransaction.Commit();
                        return base.Ok(response);
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return base.BadRequest(e);
                    }
                }
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetUsuarioRequest resetUsuarioRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.usuarioBusiness.RedefinirSenhaUsuario(resetUsuarioRequest);
                        dbContextTransaction.Commit();
                        return base.Ok(response);
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return base.BadRequest(e);
                    }
                }
            }
        }

        [HttpPut]
        [Route("Update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Update([FromBody] AtualizarUsuarioRequest atualizarUsuarioRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.usuarioBusiness.Update(atualizarUsuarioRequest);
                        dbContextTransaction.Commit();
                        return base.Ok(response);
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return base.BadRequest(e);
                    }
                }
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(Guid id)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.usuarioBusiness.Delete(id);
                        dbContextTransaction.Commit();
                        return base.Ok("Usuario deletado com sucesso");
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return base.BadRequest(e);
                    }
                }
            }
        }


        private string GerarToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["AppSettings:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = config["AppSettings:Emissor"],
                Audience = config["AppSettings:ValidoEm"],
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
