using club.van.api.business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace club.van.api.controllers
{
    [Route("api/EmpresaController")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IPerfilBusiness perfilBusiness;

        private ILogger<UsuarioController> logger;

        public EmpresaController(IPerfilBusiness perfilBusiness, ILogger<UsuarioController> logger)
        {
            this.perfilBusiness = perfilBusiness;
            this.logger = logger;
        }

        [HttpGet]
        [Route("Obter")]
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
