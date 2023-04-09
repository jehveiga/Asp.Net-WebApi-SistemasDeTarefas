using SistemasDeTarefas.Enums;

namespace SistemasDeTarefas.Models
{
    public class Tarefa : Entity
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public Guid UsuarioId { get; set; }

        // referência a propriedade de navegação do Entity Framework
        public Usuario? Usuario { get; set; }
    }
}
