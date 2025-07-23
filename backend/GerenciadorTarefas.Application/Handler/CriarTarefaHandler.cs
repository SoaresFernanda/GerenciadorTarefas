using GerenciadorTarefas.Application.Commands;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.Handler
{
    public class CriarTarefaHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public CriarTarefaHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Guid> Handle(CriarTarefaCommand command)
        {
            var novaTarefa = new Tarefa(command.Titulo, command.Descricao, command.DataCriacao);
            await _tarefaRepository.AdicionarAsync(novaTarefa);
            return novaTarefa.Id;
        }
    }
}
