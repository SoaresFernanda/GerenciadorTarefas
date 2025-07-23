using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Infrastructure.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;
        
        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ObterTodasAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> ObterPorIdAsync(Guid id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<IEnumerable<Tarefa>> ObterPorStatusAsync(StatusTarefa status)
        {
            return await _context.Tarefas
                .Where(t => t.Status == status)
                .ToListAsync();
        }
        public async Task AdicionarAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var tarefa = await ObterPorIdAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }


    }
}
