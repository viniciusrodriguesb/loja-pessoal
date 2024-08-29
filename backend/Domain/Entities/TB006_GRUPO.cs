using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TB006_GRUPO
	{
		public int NuGrupo { get; set; }
		public string NoGrupo { get; set; }	
		public decimal VrGrupo { get; set; }


		public virtual List<TB007_PRODUTO_GRUPO> ProdutosGrupoNavigation { get; set; }
		public virtual List<TB008_MOVIMENTACAO> MovimentacoesNavigation { get; set; }
		
	}
}
