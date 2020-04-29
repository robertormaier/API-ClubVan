using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.data.dto.ViagemDiasArguments;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace club.van.controllers
{

    [Route("api/ViagemDiaController")]
    [ApiController]
    public class ViagemDiaController : ControllerBase
    {
        private IViagemDiasBusiness viagemDiasBusiness;

        private ILogger<ViagemDiaController> logger;

        public ViagemDiaController(IViagemDiasBusiness viagemDiasBusiness, ILogger<ViagemDiaController> logger)
        {
            this.viagemDiasBusiness = viagemDiasBusiness;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetAll/{usuarioId}/{rotaId}/{numeroSemana}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ObterTodos(Guid usuarioId, Guid rotaId, int numeroSemana)
        {
            try
            {
                var response = this.viagemDiasBusiness.ObterTodos(usuarioId, rotaId, numeroSemana);
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
        public IActionResult Adicionar([FromBody] AdicionarViagemDiasRequest adicionarViagemDiasRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.viagemDiasBusiness.AdicionarViagemDia(adicionarViagemDiasRequest);
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

        [HttpPut]
        [Route("Update")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Update([FromBody] AtualizarViagemDiasRequest atualizarViagemDiasRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.viagemDiasBusiness.Update(atualizarViagemDiasRequest);
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(Guid id)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.viagemDiasBusiness.Delete(id);
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
