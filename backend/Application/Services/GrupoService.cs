using Application.Constantes.Enums;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Application.DTO.LogDTO;

namespace Application.Services
{
	public class GrupoService
	{
		private readonly DbContextBase _dbContext;
		private readonly ILogger<GrupoService> _logger;
		private readonly LogService _logService;

		public GrupoService(DbContextBase dbContext, ILogger<GrupoService> logger, LogService logService)
		{
			_dbContext = dbContext;
			_logger = logger;
			_logService = logService;
		}

		public async Task<bool> CriarGrupo(NovoGrupoRequest request)
		{
			if (request == null)
				new ArgumentException("Dados da requisição vazios, preencha novamente.");

			var novGrupo = new TB006_GRUPO()
			{
				NoGrupo = request.NoGrupo,
				VrGrupo = request.VrGrupo
			};

			await _dbContext.TB006_GRUPO.AddAsync(novGrupo);

			var resultado = await _dbContext.SaveChangesAsync();

			if (resultado == 0)
				return false;

			var grupoCriado = await _dbContext.TB006_GRUPO.FirstOrDefaultAsync(grupo => grupo.VrGrupo == request.VrGrupo && grupo.NoGrupo == request.NoGrupo);

			var log = new LogGrupoDTO()
			{
				Grupo = grupoCriado,
				TpOperacao = TipoOperacao.INSERCAO
			};

			await _logService.CriarLogGrupo(log);

			return true;
		}

		public async Task<bool> EditarGrupo(GrupoEditadoRequest request, int nuGrupo)
		{
			try
			{
				var grupo = await _dbContext.TB006_GRUPO.FirstOrDefaultAsync(grupo => grupo.NuGrupo == nuGrupo);

				if (grupo == null)
				{
					_logger.LogInformation("EditarGrupo: Grupo não encontrado");
					return false;
				}

				grupo.NoGrupo = request.NoGrupo;
				grupo.VrGrupo = (float)request.VrGrupo;

				_dbContext.TB006_GRUPO.Update(grupo);
				await _dbContext.SaveChangesAsync();

				var log = new LogGrupoDTO()
				{
					Grupo = grupo,
					TpOperacao = TipoOperacao.EDICAO
				};

				await _logService.CriarLogGrupo(log);

				return true;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, $"EditarGrupo: Erro ao atualizar a entidade: {ex}");
				throw;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"EditarGrupo: Erro {ex}");
				throw;
			}
		}

		public async Task<GrupoResponse> BuscarGrupo(int nuGrupo)
		{
			var grupo = await _dbContext.TB006_GRUPO
										  .AsNoTracking()
										  .Where(grupo => grupo.NuGrupo == nuGrupo)
										  .Select(grupo => new GrupoResponse()
										  {
											  NuGrupo = grupo.NuGrupo,
											  NoGrupo = grupo.NoGrupo,
											  VrGrupo = grupo.VrGrupo
										  })
										  .FirstOrDefaultAsync();

			if (grupo == null)
				return null;

			return grupo;
		}

		public async Task<bool> DeletarGrupo(int nuGrupo)
		{
			var grupoParaDeletar = _dbContext.TB006_GRUPO.FirstOrDefault(grupo => grupo.NuGrupo == nuGrupo);

			if (grupoParaDeletar == null)
			{
				_logger.LogInformation("DeletarGrupo: Grupo não encontrado");
				return false;
			}

			_dbContext.TB006_GRUPO.Remove(grupoParaDeletar);

			var resultado = await _dbContext.SaveChangesAsync();

			if (resultado == 0)
				return false;

			var log = new LogGrupoDTO()
			{
				Grupo = grupoParaDeletar,
				TpOperacao = TipoOperacao.DELECAO
			};

			await _logService.CriarLogGrupo(log);

			return true;
		}
	}
}
