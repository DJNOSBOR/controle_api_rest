using Controle.Data.Interfaces;
using Controle.Data.Models;
using Controle.Data.Models.Dto;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private IContasService _service;
        public ContasController(IContasService service)
        {
            _service = service;
        }

        /// <summary>
        /// Buscar todos os Contas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<Contas>))]
        public IActionResult GetContas()
        {
            try
            {
                var resultado = _service.GetContasAsync();
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Buscar o Contas pelo mes e ano e se estiver pago ou não
        /// </summary>
        /// <param name="pago"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("ispago/month")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<Contas>))]
        public IActionResult GetMonthIsPago(bool pago, int month, int year)
        {
            try
            {
                var resultado = _service.GetMonthIsPago(pago,month,year);
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Buscar o Contass pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Contas>))]
        public IActionResult GetContasById(int id)
        {
            try
            {
                var resultado = _service.GetContasByIdAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona as informações do Contas
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Contas>))]
        public IActionResult PostContas(LancamentoContasInsert data)
        {
            try
            {
                var resultado = _service.PostNewContaAsync(data);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona ou Altera as informações do Contas
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Contas>))]
        public IActionResult PutContas(Contas data)
        {
            try
            {
                var resultado = _service.PutContasAsync(data);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Deleta o Contas pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<bool>))]
        public IActionResult DeleteContas(int id)
        {
            try
            {
                var resultado = _service.DeleteContasAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }
    }
}
