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
        [Route("GetAll/{rotaId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ObterTodos(Guid rotaId)
        {
            try
            {
                var response = this.viagemDiasBusiness.ObterTodos(rotaId);
                return base.Ok(response);
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("ObterByUser/{usuarioId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ObterByUser(string usuarioId)
        {
            using (var context = new ClubVanContext())
            {
                try
                {
                    var response = this.viagemDiasBusiness.ObertByUser(usuarioId);
                    return base.Ok(response);
                }
                catch (System.Exception e)
                {
                    this.logger.LogInformation($"Erro:{e.Message}");
                    return BadRequest(e);
                }
            }
        }

        [HttpPost]
        [Route("Salvar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Salvar([FromBody] SalvarViagemDiasRequest salvarViagemDiasRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.viagemDiasBusiness.Salvar(salvarViagemDiasRequest);
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
