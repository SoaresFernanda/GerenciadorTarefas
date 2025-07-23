using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTodasAsync();
        Task<Tarefa> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Tarefa>> ObterPorStatusAsync(StatusTarefa status);
        Task AdicionarAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task RemoverAsync(Guid id);
    }
}
