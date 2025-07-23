using GerenciadorTarefas.Application.Commands;
using GerenciadorTarefas.Application.Handler;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly CriarTarefaHandler _handler;

        public TarefasController(CriarTarefaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarTarefaCommand command)
        {
            var id = await _handler.Handle(command);
            return CreatedAtAction(nameof(Post), new { id }, command);
        }
    }
}
