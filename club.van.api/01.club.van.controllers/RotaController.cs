using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.data.dto.RotaArguments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace club.van.api.controllers
{
    [Authorize]
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
        [Route("GetAll")]
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
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.rotaBusiness.Adicionar(adicionarRotaRequest);
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
                        this.rotaBusiness.Delete(id);
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
