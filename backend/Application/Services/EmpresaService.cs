using Application.Constantes.Enums;
using Application.DTO;
using Application.DTO.LogDTO;
using Application.DTO.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
	public class EmpresaService
	{
		private readonly DbContextBase _dbContext;
		private readonly ILogger<EmpresaService> _logger;
		private readonly LogService _logService;

		public EmpresaService(DbContextBase dbContext, ILogger<EmpresaService> logger, LogService logService)
		{
			_dbContext = dbContext;
			_logger = logger;
			_logService = logService;
		}

		public async Task<bool> CriarEmpresa(NovaEmpresaRequest request)
		{
			if (request == null)
				new ArgumentException("Dados da requisição vazios, preencha novamente.");

			var novaEmpresa = new TB002_EMPRESA()
			{
				NoEmpresa = request.NoEmpresa,
				CoCnpj = request.CoCnpj
			};

			await _dbContext.TB002_EMPRESA.AddAsync(novaEmpresa);

			var resultado = await _dbContext.SaveChangesAsync();

			if(resultado == 0)
				return false;

			var empresaCriada = await _dbContext.TB002_EMPRESA.FirstOrDefaultAsync(empresa => empresa.CoCnpj == request.CoCnpj);

			var log = new LogEmpresaDTO()
			{
				Empresa = empresaCriada,
				TpOperacao = TipoOperacao.INSERCAO
			};

			await _logService.CriarLogEmpresa(log);

			return true;
		}
	}
}
