using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Interfaces;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        // aplicando a injeção de dependencia de Tarefa
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> ListarTodasTarefas()
        {
           List<Tarefa> tarefaListagem = await _tarefaRepositorio.BuscarTodasTarefas();

            return Ok(tarefaListagem); // retorna o código 200
        }

        //[HttpGet("BuscarPorID/{id}")] Pode ser personalizado conforme necessário
        [HttpGet("{id}")] // padrão REST Personalizando a rota para ser passado o parametro id na rota
        public async Task<ActionResult<Tarefa>> BuscarUsuarioPorId(Guid id)
        {
            Tarefa tarefaDataBase = await _tarefaRepositorio.BuscasPorId(id);

            return Ok(tarefaDataBase); // retorna o código 200
        }

        // Adicionar tarefa recebendo os dados da tarefa pelo corpo da requisição
        [HttpPost]
        public async Task<ActionResult<Tarefa>> AdicionarTarefa([FromBody]Tarefa tarefa)
        {
            Tarefa tarefaAdicionado = await _tarefaRepositorio.Adicionar(tarefa);

            return Ok(tarefaAdicionado); // retorna o código 200
        }


        [HttpPut("{id}")] // padrão REST Personalizando a rota para ser passado o parametro id na rota para atualização da tarefa
        public async Task<ActionResult<Tarefa>> AtualizarTarefa([FromBody] Tarefa tarefa, Guid id)
        {
            tarefa.Id = id;
            Tarefa tarefaAtualizado = await _tarefaRepositorio.Atualizar(tarefa, id);

            return Ok(tarefaAtualizado); // retorna o código 200
        }

        [HttpDelete("{id}")] // padrão REST Personalizando a rota para ser passado o parametro id na rota para remover a tarefa
        public async Task<ActionResult<Tarefa>> DeletarTarefa(Guid id)
        {
            bool tarefaStatusRemovido= await _tarefaRepositorio.Apagar(id);

            return Ok(tarefaStatusRemovido);
        }

    }
}
