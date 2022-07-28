using MelhorRota.Data.Models;
using MelhorRota.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MelhorRota.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportoController : ControllerBase
    {
        private readonly IAeroportoService _aeroportoService;
        public AeroportoController(IAeroportoService aeroportoService)
        {
            _aeroportoService = aeroportoService;
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarAeroportos()
        {
            return Ok(await _aeroportoService.BuscarAeroportos());
        }

        [HttpGet("buscar-rotas")]
        public async Task<IActionResult> BuscarRotas()
        {
            return Ok(await _aeroportoService.BuscarRotas());
        }

        [HttpGet("buscar-melhor-rota/{origem}/{destino}")]
        public async Task<IActionResult> BuscarMelhorRota(string origem, string destino)
        {
            return Ok(await _aeroportoService.BuscarMelhorRota(origem, destino));
        }
    }
}
