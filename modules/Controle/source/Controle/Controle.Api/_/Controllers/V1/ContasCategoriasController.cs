using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasCategoriasController : ControllerBase
    {
        private IContasCategoriasService _service;
        private ILogger<ContasCategoriasController> _logger;
        public ContasCategoriasController(ILogger<ContasCategoriasController> logger  , IContasCategoriasService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Buscar todas as Categorias das Contas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<ContasCategorias>))]
        public IActionResult GetContasCategoriass()
        {
            try
            {
                var resultado = _service.GetContasCategoriasAsync();
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Buscar a Categorias das Contas pelo Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<ContasCategorias>))]
        public IActionResult GetContasCategoriasById(int id)
        {
            try
            {
                var resultado = _service.GetContasCategoriasByIdAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona ou Altera as Categorias das Contas
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<ContasCategorias>))]
        public IActionResult PostOrPutContasCategorias(ContasCategorias data)
        {
            try
            {
                var resultado = _service.PostOrPutContasCategoriasAsync(data);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Deleta a Categoria das contas pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<bool>))]
        public IActionResult DeleteContasCategorias(int id)
        {
            try
            {
                var resultado = _service.DeleteContasCategoriasAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }
    }
}
