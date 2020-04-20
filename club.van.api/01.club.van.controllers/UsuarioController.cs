using club.van.api.business.Interface;
using club.van.api.data.dto.UsuarioArguments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace club.van.api.controllers
{
    [Route("api/UsuarioController")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioBusiness usuarioBusiness;

        private ILogger<UsuarioController> logger;

        public UsuarioController(IUsuarioBusiness usuarioBusiness, ILogger<UsuarioController> logger)
        {
            this.usuarioBusiness = usuarioBusiness;

            this.logger = logger;
        }

        [HttpGet]
        [Route("AutenticarUsuario/{email}/{senha}")]
        public IActionResult AutenticarUsuario(string email, string senha)
        {
            try
            {
                var response = this.usuarioBusiness.AutenticarUsuario(email, senha);
                return base.Ok(response);
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return base.Ok(e);
            }
        }

        [HttpGet]
        [Route("ObterTodos")]
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
                var response = this.usuarioBusiness.AdicionarUsuario(adicionarUsuarioRequest);
                return base.Ok(response);
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
    }
}
