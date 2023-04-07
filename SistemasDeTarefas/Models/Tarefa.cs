using SistemasDeTarefas.Enums;

namespace SistemasDeTarefas.Models
{
    public class Tarefa : Entity
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
