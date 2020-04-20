using club.van.api.business.Interface;
using club.van.api.data.dto.RotaArguments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace club.van.api.controllers
{
    [Route("api/RotaController")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private IRotaBusiness rotaBusiness;

        private ILogger<UsuarioController> logger;

        public RotaController(IRotaBusiness rotaBusiness, ILogger<UsuarioController> logger)
        {
            this.rotaBusiness = rotaBusiness;
            this.logger = logger;
        }

        [HttpGet]
        [Route("ObterTodas")]
        public IActionResult ObterTodas()
        {
            try
            {
                var response = this.rotaBusiness.ObterTodas();
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
        public IActionResult Adicionar([FromBody] AdicionarRotaRequest adicionarRotaRequest)
        {
            try
            {
                var response = this.rotaBusiness.Adicionar(adicionarRotaRequest);
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
                this.rotaBusiness.Delete(id);
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
