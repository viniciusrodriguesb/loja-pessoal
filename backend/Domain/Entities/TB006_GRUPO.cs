namespace Domain.Entities
{
    public class TB006_GRUPO
	{
		public int NuGrupo { get; set; }
		public string NoGrupo { get; set; }	
		public decimal VrGrupo { get; set; }

		#region Navigations
		public virtual List<TB007_PRODUTO_GRUPO> ProdutosGrupoNavigation { get; set; }
		public virtual List<TB008_MOVIMENTACAO> MovimentacoesNavigation { get; set; } 
		#endregion

	}
}
