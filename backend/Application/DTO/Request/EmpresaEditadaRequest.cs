using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
	public class EmpresaEditadaRequest
	{
		[StringLength(14)]
		public string ? CoCnpj { get; set; }
		
		public string ? NoEmpresa { get; set; }
	}
}
