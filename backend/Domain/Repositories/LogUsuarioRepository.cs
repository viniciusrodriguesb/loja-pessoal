using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories
{
    public class LogUsuarioRepository : Repository<TB501_LOG_USUARIO>, ILogUsuarioRepository
    {
        public LogUsuarioRepository(DbContextBase dbContext) : base(dbContext) { }

        public async Task GerarLog(TB001_USUARIO usuario, short TipoOperacao)
        {
            var novoLog = new TB501_LOG_USUARIO()
            {
                NuUsuario = usuario.NuUsuario,
                CoSenha = usuario.CoSenha,
                IcUsuario = usuario.IcUsuario,
                NoEmail = usuario.NoEmail,
                NoUsuario = usuario.NoUsuario,
                DhOperacao = DateTime.Now,
                IcOperacao = TipoOperacao
            };

            await Adicionar(novoLog);
        }
    }
}
