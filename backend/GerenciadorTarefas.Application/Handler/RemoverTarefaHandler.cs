using GerenciadorTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.Handler
{
    public class RemoverTarefaHandler
    {
        private readonly ITarefaRepository _tarefaRepository;
        public RemoverTarefaHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<bool> Handle(Guid id)
        {
            try
            {
                await _tarefaRepository.RemoverAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
