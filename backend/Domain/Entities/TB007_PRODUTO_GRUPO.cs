namespace Domain.Entities
{
    public class TB007_PRODUTO_GRUPO
	{
		public int NuGrupo { get; set; }
		public int NuProduto { get; set; }

		#region Navigations
		public virtual TB005_PRODUTO ProdutoNavigation { get; set; }
		public virtual TB006_GRUPO GrupoNavigation { get; set; } 
		#endregion

	}
}
