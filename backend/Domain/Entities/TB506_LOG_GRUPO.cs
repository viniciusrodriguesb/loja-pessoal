using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TB506_LOG_GRUPO
	{
		public int NuLogGrupo { get; set; }
		public int NuGrupo { get; set; }
		public int NoGrupo { get; set; }
		public decimal VrGrupo { get; set; }
		public int IcOperacao { get; set; }
		public DateTime DhOperacao { get; set; }
	}
}
