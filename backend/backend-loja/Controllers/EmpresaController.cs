﻿using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]/v1")]
	[ApiController]
	[Authorize]
	public class EmpresaController : ControllerBase
	{
		private readonly EmpresaService _empresaService;
		public EmpresaController(EmpresaService empresaService) { 
			_empresaService = empresaService;
		}

		[HttpPost("criar")]
		public async Task<IActionResult> CriarEmpresa([FromBody]NovaEmpresaRequest request)
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

		[HttpGet("\"buscar/{nuEmpresa}\"")]
		public async Task<IActionResult> BuscarEmpresa(int nuEmpresa)
		{
			try
			{
				var resultado = await _empresaService.BuscarEmpresa(nuEmpresa);

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
		public async Task<IActionResult> EditarEmpresa([FromBody]EmpresaEditadaRequest request, [FromQuery]int nuEmpresa)
		{
			try
			{
				var resultado = await _empresaService.EditarEmpresa(request, nuEmpresa);

				return StatusCode(StatusCodes.Status200OK, resultado);
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
			}
		}

		[HttpDelete("deletar")]
		public async Task<IActionResult> DeletarEmpresa([FromQuery] int nuEmpresa)
		{
			try
			{
				var resultado = await _empresaService.DeletarEmpresa(nuEmpresa);

				return StatusCode(StatusCodes.Status200OK, resultado);
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
			}
		}
	}
}
