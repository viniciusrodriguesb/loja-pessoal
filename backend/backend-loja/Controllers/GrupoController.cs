using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]/v1")]
	[ApiController]
	public class GrupoController : ControllerBase
	{
		private readonly GrupoService _grupoService;
		public GrupoController(GrupoService grupoService)
		{
			_grupoService = grupoService;
		}

		[HttpPost("criar")]
		public async Task<IActionResult> CriarGrupo([FromBody] NovoGrupoRequest request)
		{
			try
			{
				var resultado = await _grupoService.CriarGrupo(request);

				return StatusCode(StatusCodes.Status200OK, resultado);
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
			}
		}

		[HttpGet("\"buscar/{nuGrupo}\"")]
		public async Task<IActionResult> BuscarGrupo(int nuGrupo)
		{
			try
			{
				var resultado = await _grupoService.BuscarGrupo(nuGrupo);

				if (resultado == null)
					return StatusCode(StatusCodes.Status204NoContent, "Grupo não encontrada.");

				return StatusCode(StatusCodes.Status200OK, resultado);
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
			}
		}

		[HttpPut("editar")]
		public async Task<IActionResult> EditarGrupo([FromBody] GrupoEditadoRequest request, [FromQuery] int nuEmpresa)
		{
			try
			{
				var resultado = await _grupoService.EditarGrupo(request, nuEmpresa);

				return StatusCode(StatusCodes.Status200OK, resultado);
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
			}
		}

		[HttpDelete("deletar")]
		public async Task<IActionResult> DeletarGrupo([FromQuery] int nuGrupo)
		{
			try
			{
				var resultado = await _grupoService.DeletarGrupo(nuGrupo);

				return StatusCode(StatusCodes.Status200OK, resultado);
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
			}
		}
	}
}
