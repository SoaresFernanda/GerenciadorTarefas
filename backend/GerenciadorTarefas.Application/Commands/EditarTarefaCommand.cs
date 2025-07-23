using GerenciadorTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.Commands
{
    public class EditarTarefaCommand
    {
        public string? NovoTitulo { get; set; }
        public string? NovaDescricao { get; set; }
    }
}
