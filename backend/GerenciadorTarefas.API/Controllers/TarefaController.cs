using GerenciadorTarefas.Application.Commands;
using GerenciadorTarefas.Application.Handler;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly CriarTarefaHandler _criarTarefaHandler;
        private readonly ListarTarefaHandler _listarHandler;
        private readonly EditarTarefaHandler _editarHandler;
        private readonly AlterarStatusTarefaHandler _alterarStatusHandler;
        private readonly RemoverTarefaHandler _removerTarefaHandler;

        public TarefasController(CriarTarefaHandler criarTarefaHandler, ListarTarefaHandler listarTarefaHandler, EditarTarefaHandler editarTarefaHandler,
            AlterarStatusTarefaHandler alterarStatusTarefaHandler, RemoverTarefaHandler removerTarefaHandler)
        {
            _criarTarefaHandler = criarTarefaHandler;
            _listarHandler = listarTarefaHandler;
            _editarHandler = editarTarefaHandler;
            _alterarStatusHandler = alterarStatusTarefaHandler;
            _removerTarefaHandler = removerTarefaHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] CriarTarefaCommand command)
        {
            var id = await _criarTarefaHandler.Handle(command);
            return CreatedAtAction(nameof(CriarTarefa), new { id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTarefas()
        {
            var tarefas = await _listarHandler.Handler();
            return Ok(tarefas);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditarTarefa([FromRoute] Guid id, [FromBody] EditarTarefaCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.NovoTitulo) && string.IsNullOrWhiteSpace(command.NovaDescricao))
                return BadRequest("Título e ou descrição não podem ser vazios.");

            var resultado = await _editarHandler.Handle(id, command.NovoTitulo, command.NovaDescricao);

            if (resultado)
                return Ok("Tarefa editada com sucesso");

            return NotFound("Tarefa não encontrada");
        }


        [HttpPatch("{id}/status")]
        public async Task<IActionResult> AlterarStatusTarefa([FromRoute] Guid id, [FromBody] AlterarStatusCommand command)
        {
            var resultado = await _alterarStatusHandler.Handle(id, command.NovoStatus.ToString());
            if (resultado)
                return NoContent();
            else
                return NotFound("Tarefa não encontrada ou status inválido");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTarefa(Guid id)
        {
            var resultado = await _removerTarefaHandler.Handle(id);
            if (resultado)
                return Ok("Tarefa removida com sucesso");
            else
                return NotFound("Tarefa não encontrada");
        }
    }
}