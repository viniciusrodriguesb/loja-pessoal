using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
	public class NovoGrupoRequest
	{
		[Required]
		public string NoGrupo { get; set; }
		[Required]
		public float VrGrupo { get; set; }
	}
}
