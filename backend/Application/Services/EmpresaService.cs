using Application.Constantes.Enums;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class EmpresaService
    {

        #region Constructor
        private readonly ILogger<EmpresaService> _logger;
        private readonly ILogEmpresaRepository _logEmpresaRepository;
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaService(IEmpresaRepository empresaRepository,
                              ILogger<EmpresaService> logger,
                              ILogEmpresaRepository logEmpresaRepository)
        {
            _empresaRepository = empresaRepository;
            _logEmpresaRepository = logEmpresaRepository;
            _logger = logger;
        }
        #endregion

        public async Task CriarEmpresa(NovaEmpresaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Dados da requisição vazios, preencha novamente.");

            var novaEmpresa = new TB002_EMPRESA()
            {
                NoEmpresa = request.NoEmpresa,
                CoCnpj = request.CoCnpj
            };

            await _empresaRepository.Adicionar(novaEmpresa);

            var empresaCriada = await _empresaRepository.BuscarEmpresaCnpj(request.CoCnpj);

            await _logEmpresaRepository.GerarLog(empresaCriada, (short)TipoOperacao.INSERCAO);

        }
        public async Task EditarEmpresa(NovaEmpresaRequest request, int NuEmpresa)
        {
            try
            {
                var empresa = await _empresaRepository.BuscarEmpresaId(NuEmpresa);

                if (empresa == null)
                    throw new ArgumentException("Empresa não encontrada");

                empresa.CoCnpj = request.CoCnpj;
                empresa.NoEmpresa = request.NoEmpresa;

                await _empresaRepository.Atualizar(empresa);

                await _logEmpresaRepository.GerarLog(empresa, (short)TipoOperacao.EDICAO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EditarEmpresa: Erro {ex.Message}");
                throw;
            }
        }
        public async Task<EmpresaResponse> BuscarEmpresa(int NuEmpresa)
        {
            var empresa = await _empresaRepository.BuscarEmpresaId(NuEmpresa);

            var response = new EmpresaResponse()
            {
                NuEmpresa = empresa.NuEmpresa,
                NoEmpresa = empresa.NoEmpresa,
                CoCnpj = empresa.CoCnpj
            };

            return response;
        }
        public async Task DeletarEmpresa(int NuEmpresa)
        {
            var empresaParaDeletar = await _empresaRepository.BuscarEmpresaId(NuEmpresa);

            if (empresaParaDeletar == null)
                throw new ArgumentException("Empresa não encontrada");

            await _empresaRepository.Remover(empresaParaDeletar);

            await _logEmpresaRepository.GerarLog(empresaParaDeletar, (short)TipoOperacao.EDICAO);
        }
    }
}
