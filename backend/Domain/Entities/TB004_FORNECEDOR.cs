namespace Domain.Entities
{
    public class TB004_FORNECEDOR
    {
        public int NuFornecedor {  get; set; }
        public int NuEmpresa { get; set; }
        public string NoFornecedor { get; set;}
        public decimal VrProdutoFornecedor { get; set; }
        public int QtProdutoFornecedor { get; set; }

        #region Navigations
        public TB002_EMPRESA EmpresaNavigation { get; set; } 
        #endregion

    }
}
