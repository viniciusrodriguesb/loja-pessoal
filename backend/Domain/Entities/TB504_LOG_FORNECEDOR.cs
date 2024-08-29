namespace Domain.Entities
{
    public class TB504_LOG_FORNECEDOR
    {
        public int NuFornecedor { get; set; }
        public int? NuEmpresa { get; set; }
        public int? QtProdutoFornecedor { get; set; }
        public string? NoProdutoFornecedor { get; set; }
        public decimal? VrProdutoFornecedor { get; set; }
        public DateTime DhOperacao { get; set; }
        public int IcOperacao { get; set; }
        public int NuLogFornecedor { get; set; }
    }
}
