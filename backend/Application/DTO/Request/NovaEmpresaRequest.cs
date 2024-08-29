using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request
{
	public class NovaEmpresaRequest
	{
		[Required]
		[StringLength(14)]
		public string CoCnpj { get; set; }
		[Required]
		public string NoEmpresa { get; set; }
	}
}
