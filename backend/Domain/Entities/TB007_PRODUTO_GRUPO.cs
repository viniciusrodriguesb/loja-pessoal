using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TB007_PRODUTO_GRUPO
	{
		public int NuGrupo { get; set; }
		public int NuProduto { get; set; }

		public virtual TB006_GRUPO GrupoNavigation { get; set; }
	}
}
