using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasParcelasController : ControllerBase
    {
        private IContasParcelasService _service;
        public ContasParcelasController(IContasParcelasService service)
        {
            _service = service;
        }

        /// <summary>
        /// Buscar todos os Contas Parcelas se esta pago e as datas de vencimento
        /// </summary>
        /// <returns></returns>
        [HttpGet("pago/datavencimento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<ContasParcelas>))]
        public IActionResult GetContasParcelasIsPago(bool isPago,DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var resultado = _service.GetParcelasIsPago(isPago,dataInicial,dataFinal);
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Buscar todos os Contas Parcelas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<ContasParcelas>))]
        public IActionResult GetContasParcelas()
        {
            try
            {
                var resultado = _service.GetContasParcelasAsync();
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Buscar o Contas Parcelas pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<ContasParcelas>))]
        public IActionResult GetContasParcelasById(int id)
        {
            try
            {
                var resultado = _service.GetContasParcelasByIdAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona ou Altera as informações do Contas Parcelas
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<ContasParcelas>))]
        public IActionResult PostOrPutContasParcelas(ContasParcelas data)
        {
            try
            {
                var resultado = _service.PostOrPutContasParcelasAsync(data);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Deleta o Contas Parcelas pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<bool>))]
        public IActionResult DeleteContasParcelas(int id)
        {
            try
            {
                var resultado = _service.DeleteContasParcelasAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }
    }
}
