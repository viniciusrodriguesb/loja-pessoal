using Application.DTO;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
	public class LogService
	{

		private readonly DbContextBase _dbContext;
		private readonly ILogger<LogService> _logger;

		public LogService(DbContextBase dbContext, ILogger<LogService> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public async Task<bool> CriarLogEmpresa(LogEmpresaDTO logEmpresa)
		{
			if (logEmpresa == null)
				new ArgumentException("Dados do log vazios, preencha novamente.");

			var novoLog = new TB502_LOG_EMPRESA()
			{
				CoCnpj = logEmpresa.Empresa.CoCnpj,
				NoEmpresa = logEmpresa.Empresa.NoEmpresa,
				NuEmpresa = logEmpresa.Empresa.NuEmpresa,
				DhOperacao = DateTime.Now,
				IcOperacao = (int)logEmpresa.TpOperacao
			};

			await _dbContext.TB502_LOG_EMPRESA.AddAsync(novoLog);

			var resultado = await _dbContext.SaveChangesAsync();

			if (resultado == 0)
				return false;

			return true;
		}

		public async Task<bool> CriarLogGrupo(LogGrupoDTO logGrupo)
		{
			if (logGrupo == null)
				new ArgumentException("Dados do log vazios, preencha novamente.");

			var novoLog = new TB506_LOG_GRUPO()
			{
				NuGrupo = logGrupo.Grupo.NuGrupo,
				NoGrupo = logGrupo.Grupo.NoGrupo,
				VrGrupo = logGrupo.Grupo.VrGrupo,
				DhOperacao = DateTime.Now,
				IcOperacao = (int)logGrupo.TpOperacao
			};

			await _dbContext.TB506_LOG_GRUPO.AddAsync(novoLog);

			var resultado = await _dbContext.SaveChangesAsync();

			if (resultado == 0)
				return false;

			return true;
		}
	}
}
