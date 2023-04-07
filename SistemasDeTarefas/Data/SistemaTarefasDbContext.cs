using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Data
{
    public class SistemaTarefasDbContext : DbContext
    {
        public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando o mapeamento dos Mappings usando a herança 'IEntityTypeConfiguration' das classes configuradas no DbSet 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaTarefasDbContext).Assembly);

            // Outra maneira de configuração dos Mappings usando a herança 'IEntityTypeConfiguration' das classes configuradas no DbSet referenciando cada DbSet
            //modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
