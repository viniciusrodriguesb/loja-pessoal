using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        #region Inicializadores e Construtor
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        #endregion

        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuario(NovoUsuarioRequest request)
        {
            try
            {
                var result = await _usuarioService.CriarUsuario(request);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            try
            {
                var result = await _usuarioService.BuscarUsuarioId(id);

                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, "Usuario não encontrado.");

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [HttpPut("editar")]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuarioEditadoRequest request, [FromQuery] int Id)
        {
            try
            {
                var result = await _usuarioService.EditarUsuario(request, Id);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarUsuario([FromBody] int Id)
        {
            try
            {
                var result = await _usuarioService.DeletarUsuario(Id);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }

    }
}
