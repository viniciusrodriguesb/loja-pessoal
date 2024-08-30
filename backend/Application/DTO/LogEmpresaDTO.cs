﻿using Application.Constantes.Enums;
using Domain.Entities;

namespace Application.DTO
{
	public class LogEmpresaDTO
	{
		public TB002_EMPRESA Empresa { get; set; }
		public TipoOperacao TpOperacao { get; set; }
	}
}
