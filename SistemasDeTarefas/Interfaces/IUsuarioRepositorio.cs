using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscasPorId(Guid id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, Guid id);
        Task<bool> Apagar(Guid id);
    }
}
