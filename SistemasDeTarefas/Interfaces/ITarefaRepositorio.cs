using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<Tarefa>> BuscarTodasTarefas();
        Task<Tarefa> BuscasPorId(Guid id);
        Task<Tarefa> Adicionar(Tarefa tarefa);
        Task<Tarefa> Atualizar(Tarefa tarefa, Guid id);
        Task<bool> Apagar(Guid id);
    }
}
