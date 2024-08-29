namespace Domain.Entities
{
    public class TB005_PRODUTO
    {
        public int NuProduto { get; set; }
        public int NuEmpresa { get; set; }
        public string NoProduto { get; set; }
        public decimal VrProduto { get; set; }

        #region Navigations
        public TB002_EMPRESA EmpresaNavigation { get; set; } 
        public List<TB008_MOVIMENTACAO> MovimentacoesNavigation { get; set; } 
        #endregion

    }
}
