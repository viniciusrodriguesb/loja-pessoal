using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        #region Inicializadores e Construtor
        private readonly FornecedorService _fornecedorService;
        public FornecedorController(FornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        } 
        #endregion

        [HttpPost("criar")]
        public async Task<IActionResult> CriarFornecedor([FromBody] NovoFornecedorRequest request)
        {
            try
            {
                var resposta = await _fornecedorService.CriarFornecedor(request);

                return StatusCode(StatusCodes.Status200OK, resposta);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [HttpGet("buscar-fornecedores/{NuEmpresa}")]
        public async Task<IActionResult> BuscarFornecedorEmpresaId(int NuEmpresa)
        {
            try
            {
                var resposta = await _fornecedorService.BuscarFornecedorEmpresaId(NuEmpresa);

                if (resposta == null)
                    return StatusCode(StatusCodes.Status404NotFound);

                return StatusCode(StatusCodes.Status200OK, resposta);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [HttpGet("buscar/{NuFornecedor}")]
        public async Task<IActionResult> BuscarFornecedorPorId(int NuFornecedor)
        {
            try
            {
                var resposta = await _fornecedorService.BuscarFornecedorPorId(NuFornecedor);

                if (resposta == null)
                    return StatusCode(StatusCodes.Status404NotFound);

                return StatusCode(StatusCodes.Status200OK, resposta);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
    }
}
