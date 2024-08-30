using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
	public class EmpresaResponse
	{
		public int NuEmpresa { get; set; }
		public string CoCnpj { get; set; }
		public string NoEmpresa { get; set; }
	}
}
