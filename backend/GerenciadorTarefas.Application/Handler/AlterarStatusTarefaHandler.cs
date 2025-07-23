using GerenciadorTarefas.Domain.Enums;
using GerenciadorTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.Handler
{
    public class AlterarStatusTarefaHandler
    {
        private readonly ITarefaRepository _tarefaRepository;
        public AlterarStatusTarefaHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task<bool> Handle(Guid id, string novoStatus)
        {
            try
            {
                var tarefa = await _tarefaRepository.ObterPorIdAsync(id);
                if (tarefa == null)
                    return false;

                if (!Enum.TryParse<StatusTarefa>(novoStatus, true, out var statusEnum))
                    throw new ArgumentException("Status inválido fornecido.");

                tarefa.AlterarStatus(statusEnum);

                await _tarefaRepository.AtualizarAsync(tarefa);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar status da tarefa", ex);
            }
        }
    }
}
