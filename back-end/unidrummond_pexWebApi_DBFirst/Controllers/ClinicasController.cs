using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unidrummond_pexWebApi_DBFirst.Interfaces;
using unidrummond_pexWebApi_DBFirst.Repositories;

namespace unidrummond_pexWebApi_DBFirst.Controllers
{
    //Define que o tipo de resposta da API será em JSON
    [Produces("application/json")]
    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]
    //Define que é um controlador API
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interdafe IClinicaRepository
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instanvia o objeto _clinicaRepository para que haja a referencia nos metodos implementados no repositorio ClinicaRepository
        /// </summary>
        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Listando todas as clinicas
        /// </summary>
        /// <returns>Uma lista com as clinicas e status doe 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clinicaRepository.GetAllClinicas());
        }
        
    }
}
