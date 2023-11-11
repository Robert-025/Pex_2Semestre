using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using unidrummond_pexWebApi_DBFirst.Domains;
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
            /// Instancia o objeto _clinicaRepository para que haja a referencia nos metodos implementados no repositorio ClinicaRepository
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
            try
            {
                //Retorna o status code e a clínica 
                return Ok(_clinicaRepository.GetAllClinicas());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            };
        }

        /// <summary>
        /// Lista uma clinica por ID
        /// </summary>
        /// <param name="id">ID da clinica que sera listada</param>
        /// <returns>A clinica que foi buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            try
            {
                //Retorna o status code e a clínica 
                return Ok(_clinicaRepository.GetClinicaById(id));
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            };
        }

        /// <summary>
        /// Lista as clínicas e seus médicos
        /// </summary>
        /// <returns>Um status code 200 - OK com uma lista de clínicas e seus médicos</returns>
        [HttpGet("medicos")]
        public IActionResult GetMedicos()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_clinicaRepository.GetMedicos());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                //Chama o método de cadastrar
                _clinicaRepository.RegisterClinica(novaClinica);

                //Retorna o status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma clínica existente
        /// </summary>
        /// <param name="id">Id da clínica que será deletada</param>
        /// <returns>Um status code 204 - NoContent</returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar
                _clinicaRepository.DeleteClinica(id);

                //Retorna o status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma clínica passando seu id na url
        /// </summary>
        /// <param name="id">Id da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            try
            {
                //Chama o método de atualizar 
                _clinicaRepository.UpdateClinica(id, clinicaAtualizada);

                //Retorna o status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

    }
}
