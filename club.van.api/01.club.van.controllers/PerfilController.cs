using club.van.api.business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace club.van.api.controllers
{
    [Authorize]
    [Route("api/PerfilController")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private IPerfilBusiness  perfilBusiness;

        private ILogger<UsuarioController> logger;

        public PerfilController(IPerfilBusiness perfilBusiness, ILogger<UsuarioController> logger)
        {
            this.perfilBusiness = perfilBusiness;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]                                                                                                            
        public IActionResult ObterTodos()
        {
            try
            {
                var response = this.perfilBusiness.ObterTodos();
                return base.Ok(response);
            }
            catch (System.Exception e)
            {
                this.logger.LogInformation($"Erro:{e.Message}");
                return base.Ok(e);
            }
        }
    }
}
