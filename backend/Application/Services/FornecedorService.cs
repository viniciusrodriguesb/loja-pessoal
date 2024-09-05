﻿using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class FornecedorService
    {
        #region Inicializadores e Construtor
        private readonly DbContextBase _dbContext;
        private readonly LogService _logService;
        public FornecedorService(DbContextBase dbContext, LogService logService)
        {
            _dbContext = dbContext;
            _logService = logService;
        }
        #endregion

        public async Task<bool> CriarFornecedor(NovoFornecedorRequest request)
        {
            var criou = false;

            if (request == null)
                new ArgumentException("Dados da requisição vazios, preencha novamente.");

            var novoProdutoFornecedor = new TB004_FORNECEDOR()
            {
                NoFornecedor = request.NoFornecedor,
                NoProdutoFornecedor = request.NoProdutoFornecedor,
                QtProdutoFornecedor = request.QtProdutoFornecedor,
                VrProdutoFornecedor = request.VrProdutoFornecedor,
                NuEmpresa = request.NuEmpresa
            };

            await _dbContext.TB004_FORNECEDOR.AddAsync(novoProdutoFornecedor);
            var resultado = await _dbContext.SaveChangesAsync();

            if (resultado == 0)
                criou = false;

            criou = true;

            return criou;
        }

        public async Task<List<FornecedorResponse>> BuscarFornecedorEmpresaId(int NuEmpresa)
        {
            return await _consultarFornecedorEmpresa(NuEmpresa);
        }

        #region Métodos Privados - BuscarFornecedorEmpresaId
        private async Task<List<FornecedorResponse>> _consultarFornecedorEmpresa(int NuEmpresa)
        {
            return await _dbContext.TB004_FORNECEDOR.AsNoTracking()
                                                    .Where(x => x.NuEmpresa == NuEmpresa)
                                                    .Select(f => new FornecedorResponse()
                                                    {
                                                        NoFornecedor = f.NoFornecedor,
                                                        NoProdutoFornecedor = f.NoFornecedor,
                                                        QtProdutoFornecedor = f.QtProdutoFornecedor,
                                                        VrProdutoFornecedor = f.VrProdutoFornecedor
                                                    }).ToListAsync();
        }
        #endregion

        public async Task<FornecedorResponse> BuscarFornecedorPorId(int NuFornecedor)
        {
            return await _consultarFornecedor(NuFornecedor);
        }

        #region Métodos Privados - BuscarFornecedorPorId
        private async Task<FornecedorResponse> _consultarFornecedor(int NuFornecedor)
        {
            return await _dbContext.TB004_FORNECEDOR.AsNoTracking()
                                                    .Where(x => x.NuFornecedor == NuFornecedor)
                                                    .Select(f => new FornecedorResponse()
                                                    {
                                                        NoFornecedor = f.NoFornecedor,
                                                        NoProdutoFornecedor = f.NoFornecedor,
                                                        QtProdutoFornecedor = f.QtProdutoFornecedor,
                                                        VrProdutoFornecedor = f.VrProdutoFornecedor
                                                    }).FirstOrDefaultAsync();
        }
        #endregion


    }
}