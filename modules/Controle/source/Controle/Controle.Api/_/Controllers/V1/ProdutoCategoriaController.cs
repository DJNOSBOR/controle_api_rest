using Controle.Data.Interfaces;
using Controle.Data.Models;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoCategoriaController : ControllerBase
    {
        private IProdutoCategoriaService _service;
        public ProdutoCategoriaController(IProdutoCategoriaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca todos os ProdutoCategorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultList<ProdutoCategoria>))]
        public IActionResult GetProdutoCategorias()
        {
            try
            {
                var resultado = _service.GetProdutoCategoriaAsync();
                return Ok(resultado.Result.ToResultList());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Busca o ProdutoCategorias por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<ProdutoCategoria>))]
        public IActionResult GetProdutoCategoria(int id)
        {
            try
            {
                var resultado = _service.GetProdutoCategoriaByIdAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

        /// <summary>
        /// Adiciona ou Altera o ProdutoCategoria
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<ProdutoCategoria>))]
        public IActionResult PostOrPutProdutoCategoria(ProdutoCategoria data)
        {
            try
            {
                var resultado = _service.PostOrPutProdutoCategoriaAsync(data);
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
        public IActionResult DeleteProdutoCategoria(int id)
        {
            try
            {
                var resultado = _service.DeleteProdutoCategoriaAsync(id);
                return Ok(resultado.Result.ToResult());

            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }
    }
}
