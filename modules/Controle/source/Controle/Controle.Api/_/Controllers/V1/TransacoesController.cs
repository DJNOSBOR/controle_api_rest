using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private ITransacoesService _service;
        public TransacoesController(ITransacoesService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca todos os Transacoess
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<Transacoes>))]
        public IActionResult GetTransacoess()
        {
            try
            {
                var resultado = _service.GetTransacoesAsync();
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Busca o Transacoess por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Transacoes>))]
        public IActionResult GetTransacoes(int id)
        {
            try
            {
                var resultado = _service.GetTransacoesByIdAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona ou Altera o Transacoes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Transacoes>))]
        public IActionResult PostOrPutTransacoes(Transacoes data)
        {
            try
            {
                var resultado = _service.PostOrPutTransacoesAsync(data);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Deleta o produto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<bool>))]
        public IActionResult DeleteTransacoes(int id)
        {
            try
            {
                var resultado = _service.DeleteTransacoesAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }
    }
}
