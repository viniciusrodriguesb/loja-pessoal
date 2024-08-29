using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]/v1")]
	[ApiController]
	public class EmpresaController : ControllerBase
	{
		private readonly EmpresaService _empresaService;
		public EmpresaController(EmpresaService empresaService) { 
			_empresaService = empresaService;
		}

		[HttpPost("criar")]
		public async Task<IActionResult> CriarEmpresa(NovaEmpresaRequest request)
		{
			try
			{
				var resultado = await _empresaService.CriarEmpresa(request);

				return StatusCode(StatusCodes.Status200OK, resultado);
			}
			catch(Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
			}
		}
	}
}
