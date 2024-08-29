namespace Domain.Entities
{
    public class TB008_MOVIMENTACAO
	{
		public int NuMovimentacao { get; set; }
		public int TpPagamento { get; set; }
		public int NuGrupo { get; set; }
		public int NuProduto { get; set; }
		public DateTime DhEvento { get; set; }

		#region Navigations
		public virtual TB006_GRUPO GrupoNavigation { get; set; }
		public virtual TB005_PRODUTO ProdutoNavigation { get; set; } 
		#endregion

	}
}
