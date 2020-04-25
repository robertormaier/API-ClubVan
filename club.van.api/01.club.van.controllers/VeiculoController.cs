using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.data.dto.VeiculoArguments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace club.van.api.controllers
{
    [Authorize]
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
        [Route("GetAll")]
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
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.veiculoBusiness.AdicionarVeiculo(adicionarVeiculoRequest);
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
                        this.veiculoBusiness.Delete(id);
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
