﻿using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.data.dto.VeiculoArguments;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Route("GetAll")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("Adicionar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Adicionar([FromBody] AdicionarVeiculoRequest adicionarVeiculoRequest)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var response = this.veiculoBusiness.AdicionarVeiculo(adicionarVeiculoRequest);
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(Guid id)
        {
            using (var context = new ClubVanContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.veiculoBusiness.Delete(id);
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
