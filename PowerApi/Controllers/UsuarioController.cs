using Microsoft.AspNetCore.Mvc;
using PowerApi.Application.Entitys;
using PowerApi.Application.Interfaces;
using PowerApi.Application.Interfaces.Services;

namespace PowerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : PowerApiController
    {
        private readonly IUsuarioService UsuarioService;

        public UsuarioController(INotificationService notificationService,
            IUsuarioService usuarioService) : base(notificationService)
        {
            UsuarioService = usuarioService;
        }

        [HttpGet("ObterTodosAsync")]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return CustomResponse(await UsuarioService.ObterTodosAsync());
        }

        [HttpPost("AdicionarAsync")]
        public async Task<IActionResult> AdicionarAsync([FromBody] Usuario usuario)
        {
            return CustomResponse(await UsuarioService.AdicionarAsync(usuario));
        }

        [HttpPut("AtualizarAsync")]
        public async Task<IActionResult> AtualizarAsync(Usuario usuario)
        {
            return CustomResponse(await UsuarioService.AtualizarAsync(usuario));
        }

        [HttpPut("BanirAsync/{id}")]
        public async Task<IActionResult> BanirAsync(int id)
        {
            return CustomResponse(await UsuarioService.BanirAsync(id));
        }

        [HttpPut("InativarAsync/{id}")]
        public async Task<IActionResult> InativarAsync(int id)
        {
            return CustomResponse(await UsuarioService.InativarAsync(id));
        }

        [HttpPut("SuspenderAsync/{id}")]
        public async Task<IActionResult> SuspenderAsync(int id)
        {
            return CustomResponse(await UsuarioService.SuspenderAsync(id));
        }
    }
}
