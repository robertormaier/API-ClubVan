using club.van.api.business.Interface;
using club.van.api.data.dto.VeiculoArguments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace club.van.api.controllers
{
    [Route("api/VeiculoController")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoBusiness veiculoBusiness;

        private ILogger<UsuarioController> logger;

        public VeiculoController(IVeiculoBusiness veiculoBusiness, ILogger<UsuarioController> logger)
        {
            this.veiculoBusiness = veiculoBusiness;
            this.logger = logger;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var response = this.veiculoBusiness.ObterTodos();
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
        public IActionResult Adicionar([FromBody] AdicionarVeiculoRequest adicionarVeiculoRequest)
        {
            try
            {
                var response = this.veiculoBusiness.AdicionarVeiculo(adicionarVeiculoRequest);
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
                this.veiculoBusiness.Delete(id);
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
