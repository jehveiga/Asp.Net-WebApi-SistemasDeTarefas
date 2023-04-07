using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Interfaces;
using SistemasDeTarefas.Repositorios;

namespace SistemasDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add servi�o do Contexto de dados
            builder.Services
                    .AddDbContext<SistemaTarefasDbContext>(options => 
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add servi�o de inje��o de depend�ncias 
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}