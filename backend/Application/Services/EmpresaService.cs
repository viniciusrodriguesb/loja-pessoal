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
		private readonly ILogger<EmpresaService> _ilogger;

		public EmpresaService(DbContextBase dbContext, ILogger<EmpresaService> ilogger )
		{
			_dbContext = dbContext;
			_ilogger = ilogger;
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

			return true;
		}
	}
}
