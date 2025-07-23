using GerenciadorTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.Handler
{
    public class EditarTarefaHandler
    {
        private readonly ITarefaRepository _tarefaRepository;
        public EditarTarefaHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<bool> Handle(Guid id, string? novoTitulo, string? novaDescricao)
        {
            try
            {
                var tarefaExistente = await _tarefaRepository.ObterPorIdAsync(id);

                if (tarefaExistente == null)
                    return false;

                tarefaExistente.Atualizar(novoTitulo, novaDescricao);

                await _tarefaRepository.AtualizarAsync(tarefaExistente);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar tarefa", ex);
            }
        }
    }
}
