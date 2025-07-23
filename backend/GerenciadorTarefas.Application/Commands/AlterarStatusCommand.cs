using GerenciadorTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.Commands
{
    public class AlterarStatusCommand
    {
        public StatusTarefa NovoStatus { get; set; }
    }
}
