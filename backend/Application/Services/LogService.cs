using Application.DTO.LogDTO;
using Domain;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class LogService
    {

        #region Inicializadores e Construtor
        private readonly DbContextBase _dbContext;
        private readonly ILogger<LogService> _logger;
        private readonly ILogUsuarioRepository _logUsuarioRepository;
        public LogService(DbContextBase dbContext,
                          ILogger<LogService> logger,
                          ILogUsuarioRepository logUsuarioRepository)
        {
            _logUsuarioRepository = logUsuarioRepository;
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public async Task CriarLogUsuario(LogUsuarioDTO log)
        {
            if (log == null)
                throw new ArgumentException("Dados do log vazios, preencha novamente.");

            var novoLog = new TB501_LOG_USUARIO()
            {
                NuUsuario = log.Usuario.NuUsuario,
                CoSenha = log.Usuario.CoSenha,
                IcUsuario = log.Usuario.IcUsuario,
                NoEmail = log.Usuario.NoEmail,
                NoUsuario = log.Usuario.NoUsuario,
                DhOperacao = DateTime.Now,
                IcOperacao = (short)log.TpOperacao
            };

            await _logUsuarioRepository.Adicionar(novoLog);
        }
        public async Task CriarLogEmpresa(LogEmpresaDTO logEmpresa)
        {
            if (logEmpresa == null)
                throw new ArgumentException("Dados do log vazios, preencha novamente.");

            var novoLog = new TB502_LOG_EMPRESA()
            {
                CoCnpj = logEmpresa.Empresa.CoCnpj,
                NoEmpresa = logEmpresa.Empresa.NoEmpresa,
                NuEmpresa = logEmpresa.Empresa.NuEmpresa,
                DhOperacao = DateTime.Now,
                IcOperacao = (short)logEmpresa.TpOperacao
            };

            await _dbContext.TB502_LOG_EMPRESA.AddAsync(novoLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}
