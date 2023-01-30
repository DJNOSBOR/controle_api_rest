using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private ITarefaService _service;
        public TarefaController(ITarefaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Buscar todos os Tarefas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<Tarefa>))]
        public IActionResult GetTarefas()
        {
            try
            {
                var resultado = _service.GetTarefaAsync();
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Buscar o Tarefas pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Tarefa>))]
        public IActionResult GetTarefaById(int id)
        {
            try
            {
                var resultado = _service.GetTarefaByIdAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona ou Altera as informações do Tarefa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Tarefa>))]
        public IActionResult PostOrPutTarefa(Tarefa data)
        {
            try
            {
                var resultado = _service.PostOrPutTarefaAsync(data);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Deleta o Tarefa pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<bool>))]
        public IActionResult DeleteTarefa(int id)
        {
            try
            {
                var resultado = _service.DeleteTarefaAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Deleta o TarefaItem pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("item")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<bool>))]
        public IActionResult DeleteTarefaItem(int id)
        {
            try
            {
                var resultado = _service.DeleteTarefaItemAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }
    }
}
