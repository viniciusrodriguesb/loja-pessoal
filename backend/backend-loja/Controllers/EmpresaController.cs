using Application.DTO.Request;
using Application.DTO.Response;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public class EmpresaController : ControllerBase
    {
        #region Inicializadores e Construtor
        private readonly EmpresaService _empresaService;
        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }
        #endregion

        [HttpPost("criar")]
        [SwaggerOperation(Summary = "Realiza a criação de uma empresa")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarEmpresa([FromBody] NovaEmpresaRequest request)
        {
            try
            {
                await _empresaService.CriarEmpresa(request);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }

        [HttpGet("buscar/{NuEmpresa}")]
        [SwaggerOperation(Summary = "Obtém informações da empresa pelo ID")]
        [ProducesResponseType(typeof(EmpresaResponse), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarEmpresa(int NuEmpresa)
        {
            try
            {
                var resultado = await _empresaService.BuscarEmpresa(NuEmpresa);

                if (resultado == null)
                    return StatusCode(StatusCodes.Status204NoContent, "Empresa não encontrada.");

                return StatusCode(StatusCodes.Status200OK, resultado);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }

        [HttpPut("editar")]
        [SwaggerOperation(Summary = "Edita dados de uma empresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarEmpresa([FromBody] NovaEmpresaRequest request, [FromQuery] int nuEmpresa)
        {
            try
            {
                await _empresaService.EditarEmpresa(request, nuEmpresa);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }

        [SwaggerOperation(Summary = "Remove uma empresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarEmpresa([FromQuery] int nuEmpresa)
        {
            try
            {
                await _empresaService.DeletarEmpresa(nuEmpresa);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
    }
}
