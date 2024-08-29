using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TB502_LOG_EMPRESA
	{
		public int NuLogEmpresa { get; set; }
		public int NuEmpresa { get; set; }
		public string CoCnpj { get; set; }
		public string NoEmpresa { get; set; }
		public int IcOperacao { get; set; }
		public DateTime DhOperacao { get; set; }
	}
}
