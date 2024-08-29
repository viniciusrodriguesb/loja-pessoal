namespace Domain.Entities
{
	public class TB002_EMPRESA
	{
		public int NuEmpresa { get; set; }
		public string CoCnpj { get; set; }
		public string NoEmpresa { get; set; }

		#region Navigations
		public virtual List<TB003_USUARIO_EMPRESA> UsuariosEmpresaNavigation { get; set; } 
		public virtual List<TB004_FORNECEDOR> FornecedoresNavigation { get; set; }
		public virtual List<TB005_PRODUTO> ProdutosNavigation { get; set; }
		#endregion

	}
}
