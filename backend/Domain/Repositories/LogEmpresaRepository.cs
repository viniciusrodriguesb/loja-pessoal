using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories
{
    public class LogEmpresaRepository : Repository<TB502_LOG_EMPRESA>, ILogEmpresaRepository
    {
        public LogEmpresaRepository(DbContextBase dbContext) : base(dbContext) { }

        public async Task GerarLog(TB002_EMPRESA empresa, short TipoOperacao)
        {
            var novoLog = new TB502_LOG_EMPRESA()
            {
                NuEmpresa = empresa.NuEmpresa,
                CoCnpj = empresa.CoCnpj,
                NoEmpresa = empresa.NoEmpresa,
                DhOperacao = DateTime.Now,
                IcOperacao = TipoOperacao
            };

            await Adicionar(novoLog);
        }
    }
}
