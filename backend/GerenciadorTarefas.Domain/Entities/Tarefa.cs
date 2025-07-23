using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Domain.Entities
{

    public class Tarefa
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public StatusTarefa Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataConclusao { get; set; }
        private Tarefa() { }

        public Tarefa(string titulo, string descricao, DateTime? dataCriacao)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao ?? DateTime.UtcNow;
            Status = StatusTarefa.Pendente; 
        }

        public void Atualizar(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public void MarcarComoConcluida()
        {
            Status = StatusTarefa.Concluida;
            DataConclusao = DateTime.UtcNow;
        }

        public void AlterarStatus(StatusTarefa novoStatus)
        {
            Status = novoStatus;
        }
    }
}
