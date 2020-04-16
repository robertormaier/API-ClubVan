using club.van.api.business.Interface;
using club.van.api.data.dto.UsuarioArguments;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace club.van.api.controllers
{

    [Route("api/UsuarioController")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioBusiness usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            this.usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        [Route("Obter/{email}/{senha}")]
        public IActionResult Obter(string email, string senha)
        {
            try
            {
                var response = this.usuarioBusiness.AutenticarUusuario(email, senha);
                return base.Ok(response);
            }
            catch (System.Exception e)
            {
                return base.Ok(e);
            }
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar([FromBody] string value)
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("Update/{id}")]
        public void Update(int id, [FromBody] string value)
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
