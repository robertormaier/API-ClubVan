using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.data.dto.ViagemDiasArguments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace club.van.controllers
{
    [Authorize]
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
        [Route("GetAll/{usuarioId}/{empresaId}/{numeroSemana}")]
        public IActionResult ObterTodos(Guid usuarioId, Guid empresaId, int numeroSemana)
        {
            try
            {
                var response = this.viagemDiasBusiness.ObterTodos(usuarioId, empresaId, numeroSemana);
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
        public IActionResult Adicionar([FromBody] AdicionarViagemDiasRequest adicionarViagemDiasRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.viagemDiasBusiness.AdicionarViagemDia(adicionarViagemDiasRequest);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return base.Ok(response);
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return base.Ok(e);
                    }
                }
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] AtualizarViagemDiasRequest atualizarViagemDiasRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.viagemDiasBusiness.Update(atualizarViagemDiasRequest);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return base.Ok(response);
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return base.Ok(e);
                    }
                }
            }
        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.viagemDiasBusiness.Delete(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return base.Ok();
                    }
                    catch (System.Exception e)
                    {
                        dbContextTransaction.Rollback();
                        this.logger.LogInformation($"Erro:{e.Message}");
                        return base.Ok(e);
                    }
                }
            }
        }
    }
}
