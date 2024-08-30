using Application.Constantes.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
	public class LogEmpresaDTO
	{
		public TB002_EMPRESA Empresa { get; set; }
		public TipoOperacao TpOperacao { get; set; }
	}
}
