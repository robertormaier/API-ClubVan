using club.van.api.business.Interface;
using club.van.api.data.dto.UsuarioArguments;
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
    [Authorize]
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

        [HttpGet]
        [Route("AutenticarUsuario/{email}/{senha}")]
        public IActionResult AutenticarUsuario(string email, string senha)
        {
            try
            {
                var response = this.usuarioBusiness.AutenticarUsuario(email, senha);

                if (response == true)
                {
                    return base.Ok(GerarToken(email));
                }

                return BadRequest("Usuario ou senha invalida");
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return base.Ok(e);
            }
        }

        [HttpGet]
        [Route("GetAll")]
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
                return base.Ok(e);
            }
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar([FromBody] AdicionarUsuarioRequest adicionarUsuarioRequest)
        {
            try
            {


                this.usuarioBusiness.AdicionarUsuario(adicionarUsuarioRequest);
                return base.Ok(GerarToken(adicionarUsuarioRequest.Email));
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return base.Ok(e);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] AtualizarUsuarioRequest atualizarUsuarioRequest)
        {
            try
            {
                var response = this.usuarioBusiness.Update(atualizarUsuarioRequest);
                return base.Ok(response);
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return base.Ok(e);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                this.usuarioBusiness.Delete(id);
                return base.Ok();
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return base.Ok(e);
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
