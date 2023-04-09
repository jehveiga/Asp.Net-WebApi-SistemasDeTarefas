using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Interfaces;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public TarefaRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext; // Adicionando a injeção de dependência do DbContext
        }

        public async Task<List<Tarefa>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .AsNoTracking()
                .Include(t => t.Usuario)
                .ToListAsync();
        }

        public async Task<Tarefa> BuscasPorId(Guid id)
        {
            var tarefaDataBase = await _dbContext.Tarefas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tarefaDataBase is null)
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados.");

            return tarefaDataBase;
        }

        public async Task<Tarefa> Adicionar(Tarefa tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa); // Adicionando uma nova tarefa no contexto
            await _dbContext.SaveChangesAsync(); // Salvando as atualizações do contexto

            return tarefa;
        }
        public async Task<Tarefa> Atualizar(Tarefa tarefa, Guid id)
        {
            var tarefaDataBase = await BuscasPorId(id);
            if (tarefaDataBase is null)
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados.");

            tarefaDataBase.Nome = tarefa.Nome;
            tarefaDataBase.Status = tarefa.Status;
            tarefaDataBase.Descricao = tarefa.Descricao;
            tarefaDataBase.Usuario = tarefa.Usuario;

            _dbContext.Tarefas.Update(tarefaDataBase); // Atualizando o contexto
            await _dbContext.SaveChangesAsync(); // Salvando as atualizações do contexto

            return tarefaDataBase;
        }

        public async Task<bool> Apagar(Guid id)
        {
            var tarefaDataBase = await BuscasPorId(id);
            if (tarefaDataBase is null)
                throw new Exception($"Tarefa para o ID:  {id}  não foi encontrada no banco de dados.");

            _dbContext.Tarefas.Remove(tarefaDataBase); // Removendo a tarefa do contexto
            await _dbContext.SaveChangesAsync(); // Salvando as atualizações do contexto
            return true;
        }
    }
}
