namespace Domain.Entities
{
    public class TB508_LOG_MOVIMENTACAO
	{
		public int NuLogMovimentacao { get; set; }
		public int NuMovimentacao { get; set; }
		public int TpPagamento { get; set; }
		public int NuProduto {  get; set; }
		public int NuGrupo { get; set; }
		public DateTime DhEvento { get; set; }
		public int IcOperacao { get; set; }
		public DateTime DhOperacao { get; set; }
	}
}
