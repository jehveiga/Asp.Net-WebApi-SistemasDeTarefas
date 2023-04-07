using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Interfaces;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext; // Adicionando a injeção de dependência do DbContext
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> BuscasPorId(Guid id)
        {
            var usuarioDataBase = await _dbContext.Usuarios.FindAsync(id);
            if (usuarioDataBase is null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");

            return usuarioDataBase;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario); // Adicionando o novo usuário no contexto
            await _dbContext.SaveChangesAsync(); // Salvando as atualizações do contexto

            return usuario;
        }
        public async Task<Usuario> Atualizar(Usuario usuario, Guid id)
        {
            var usuarioDataBase = await BuscasPorId(id);
            if (usuarioDataBase is null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");

            usuarioDataBase.Nome = usuario.Nome;
            usuarioDataBase.Email = usuario.Email;

            _dbContext.Update(usuarioDataBase); // Atualizando o contexto
            await _dbContext.SaveChangesAsync(); // Salvando as atualizações do contexto

            return usuario;
        }

        public async Task<bool> Apagar(Guid id)
        {
            var usuarioDataBase = await BuscasPorId(id);
            if (usuarioDataBase is null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");

            _dbContext.Remove(usuarioDataBase); // Removendo o usuário do contexto
            await _dbContext.SaveChangesAsync(); // Salvando as atualizações do contexto
            return true;
        }
    }
}
