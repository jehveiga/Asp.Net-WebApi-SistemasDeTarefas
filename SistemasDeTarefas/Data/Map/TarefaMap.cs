using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Data.Map
{
    // Classe usada para configuração do mapeamento quando for criada a classe Tarefa pelo Entity
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Descricao).HasMaxLength(1000);
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.UsuarioId);

            builder.HasOne(t => t.Usuario);
        }
    }
}
