using Application.DTO.LogDTO;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class LogService
    {

        #region Inicializadores e Construtor
        private readonly DbContextBase _dbContext;
        private readonly ILogger<LogService> _logger;
        public LogService(DbContextBase dbContext, ILogger<LogService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public async Task<bool> CriarLogUsuario(LogUsuarioDTO log)
        {
            if (log == null)
                new ArgumentException("Dados do log vazios, preencha novamente.");

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

            await _dbContext.TB501_LOG_USUARIO.AddAsync(novoLog);
            var resultado = await _dbContext.SaveChangesAsync();

            if (resultado == 0)
                return false;

            return true;
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
                IcOperacao = (short)logEmpresa.TpOperacao
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
