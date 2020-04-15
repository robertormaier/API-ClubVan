using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace club.van.controllers
{
    [Route("api/ViagemDiaController")]
    [ApiController]
    public class ViagemDiaController : ControllerBase
    {
        [HttpGet]
        [Route("Obter/{id}")]
        public string Obter(int id)
        {
            try
            {
                return "Viagens";
            }
            catch (System.Exception)
            {

                throw;
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
