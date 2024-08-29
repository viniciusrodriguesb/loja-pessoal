using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TB507_LOG_PRODUTO_GRUPO
	{
		public int NuLogProdutoGrupo { get; set; }
		public int NuProduto { get; set; }
		public int NuGrupo { get; set; }
		public int IcOperacao { get; set; }
		public DateTime DhOperacao { get; set; }
	}
}
