using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private ICarteiraService _service;
        public CarteiraController(ICarteiraService service)
        {
            _service = service;
        }

        /// <summary>
        /// Buscar todos os Carteiras
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<Carteira>))]
        public IActionResult GetCarteiras()
        {
            try
            {
                var resultado = _service.GetCarteiraAsync();
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Buscar o Carteiras pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Carteira>))]
        public IActionResult GetCarteiraById(int id)
        {
            try
            {
                var resultado = _service.GetCarteiraByIdAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona ou Altera as informações do Carteira
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Carteira>))]
        public IActionResult PostOrPutCarteira(Carteira data)
        {
            try
            {
                var resultado = _service.PostOrPutCarteiraAsync(data);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Deleta o Carteira pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<bool>))]
        public IActionResult DeleteCarteira(int id)
        {
            try
            {
                var resultado = _service.DeleteCarteiraAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }
    }
}
