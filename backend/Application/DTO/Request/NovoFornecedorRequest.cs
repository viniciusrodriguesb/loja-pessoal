using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request
{
    public class NovoFornecedorRequest
    {
        [Required]
        public int NuEmpresa { get; set; }
        [Required]
        public string NoFornecedor { get; set; }
        [Required]
        public string NoProdutoFornecedor { get; set; }
        [Required]
        public float VrProdutoFornecedor { get; set; }
        [Required]
        public int QtProdutoFornecedor { get; set; }
    }
}
