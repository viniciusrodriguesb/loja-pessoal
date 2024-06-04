using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly ServiceTeste _testeService;
        public TesteController(ServiceTeste testeService)
        {
            _testeService = testeService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = _testeService.Get();

            return StatusCode(200, result);
        }

    }
}
