using Application.Constantes.Enums;
using Application.DTO.LogDTO;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class EmpresaService
    {

        #region Constructor
        private readonly DbContextBase _dbContext;
        private readonly ILogger<EmpresaService> _logger;
        private readonly LogService _logService;
        public EmpresaService(DbContextBase dbContext, ILogger<EmpresaService> logger, LogService logService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _logService = logService;
        } 
        #endregion

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

            if (resultado == 0)
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

        public async Task<bool> EditarEmpresa(NovaEmpresaRequest request, int nuEmpresa)
        {
            try
            {
                var empresa = await _dbContext.TB002_EMPRESA.FirstOrDefaultAsync(empresa => empresa.NuEmpresa == nuEmpresa);

                if (empresa == null)
                {
                    _logger.LogInformation("EditarEmpresa: Empresa não encontrada");
                    return false;
                }

                empresa.CoCnpj = request.CoCnpj;
                empresa.NoEmpresa = request.NoEmpresa;

                _dbContext.TB002_EMPRESA.Update(empresa);
                await _dbContext.SaveChangesAsync();

                var log = new LogEmpresaDTO()
                {
                    Empresa = empresa,
                    TpOperacao = TipoOperacao.EDICAO
                };

                await _logService.CriarLogEmpresa(log);

                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"EditarEmpresa: Erro ao atualizar a entidade: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EditarEmpresa: Erro {ex}");
                throw;
            }
        }

        public async Task<EmpresaResponse> BuscarEmpresa(int nuEmpresa)
        {
            var empresa = await _dbContext.TB002_EMPRESA
                                          .AsNoTracking()
                                          .Where(empresa => empresa.NuEmpresa == nuEmpresa)
                                          .Select(empresa => new EmpresaResponse()
                                          {
                                              NuEmpresa = empresa.NuEmpresa,
                                              NoEmpresa = empresa.NoEmpresa,
                                              CoCnpj = empresa.CoCnpj
                                          })
                                          .FirstOrDefaultAsync();

            if (empresa == null)
                return null;

            return empresa;
        }

        public async Task<bool> DeletarEmpresa(int nuEmpresa)
        {
            var empresaParaDeletar = _dbContext.TB002_EMPRESA.FirstOrDefault(empresa => empresa.NuEmpresa == nuEmpresa);

            if (empresaParaDeletar == null)
            {
                _logger.LogInformation("DeletarEmpresa: Empresa não encontrada");
                return false;
            }

            _dbContext.TB002_EMPRESA.Remove(empresaParaDeletar);

            var resultado = await _dbContext.SaveChangesAsync();

            if (resultado == 0)
                return false;

            var log = new LogEmpresaDTO()
            {
                Empresa = empresaParaDeletar,
                TpOperacao = TipoOperacao.DELECAO
            };

            await _logService.CriarLogEmpresa(log);

            return true;
        }
    }
}
