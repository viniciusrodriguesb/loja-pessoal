using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions options)
            : base(options)
        {
        }

        #region Modelos
        //public DbSet<CategoriaProdutoModel> CategoriaProdutoModel { get; set; }
        //public DbSet<ClienteModel> ClienteModel { get; set; }
        //public DbSet<EmpresaModel> EmpresaModel { get; set; }
        //public DbSet<EstoqueModel> EstoqueModel { get; set; }
        //public DbSet<FornecedorModel> FornecedorModel { get; set; }
        //public DbSet<PedidoModel> PedidoModel { get; set; }
        //public DbSet<ProdutoModel> ProdutoModel { get; set; }
        public DbSet<UsuarioModel> UsuarioModel { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}
