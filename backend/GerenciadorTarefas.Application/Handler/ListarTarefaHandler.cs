using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.Handler
{
    public class ListarTarefaHandler
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ListarTarefaHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<Tarefa>> Handler()
        {
            try
            {
                return await _tarefaRepository.ObterTodasAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar tarefas", ex);
            }
        }
    }
}
