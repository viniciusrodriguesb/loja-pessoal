using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class EmpresaRepository : Repository<TB002_EMPRESA>, IEmpresaRepository
    {

        public EmpresaRepository(DbContextBase dbContext) : base(dbContext) { }
               
        public async Task<TB002_EMPRESA?> BuscarEmpresaCnpj(string CNPJ)
        {
            return await _dbContext.TB002_EMPRESA.FirstOrDefaultAsync(empresa => empresa.CoCnpj == CNPJ);
        }
        public async Task<TB002_EMPRESA?> BuscarEmpresaId(int NuEmpresa)
        {
            return await _dbContext.TB002_EMPRESA.FirstOrDefaultAsync(empresa => empresa.NuEmpresa == NuEmpresa);
        }     
    }
}
