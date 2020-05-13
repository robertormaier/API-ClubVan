using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.data.dto.RotaArguments;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Route("GetAll/{empresaId}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ObterTodas(string empresaId)
        {
            try
            {
                var response = this.rotaBusiness.ObterTodas(empresaId);
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Adicionar([FromBody] AdicionarRotaRequest adicionarRotaRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.rotaBusiness.Adicionar(adicionarRotaRequest);
                        dbContextTransaction.Commit();
                        return base.Ok(response);
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return BadRequest(e);
                    }
                }
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(Guid id)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.rotaBusiness.Delete(id);
                        dbContextTransaction.Commit();
                        return base.Ok();
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return BadRequest(e);
                    }
                }
            }
        }
    }
}
