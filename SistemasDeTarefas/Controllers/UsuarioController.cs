using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Interfaces;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        // aplicando a injeção de dependencia de Usuario
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
           List<Usuario> usuarioListagem = await _usuarioRepositorio.BuscarTodosUsuarios();

            return Ok(usuarioListagem); // retorna o código 200
        }

        //[HttpGet("BuscarPorID/{id}")] Pode ser personalizado conforme necessário
        [HttpGet("{id}")] // padrão REST Personalizando a rota para ser passado o parametro id na rota
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorId(Guid id)
        {
            Usuario usuarioDataBase = await _usuarioRepositorio.BuscasPorId(id);

            return Ok(usuarioDataBase); // retorna o código 200
        }

        // Adicionar usuário recebendo os dados do usuário pelo corpo da requisição
        [HttpPost]
        public async Task<ActionResult<Usuario>> AdicionarUsuario([FromBody]Usuario usuario)
        {
            Usuario usuarioAdicionado = await _usuarioRepositorio.Adicionar(usuario);

            return Ok(usuarioAdicionado); // retorna o código 200
        }


        [HttpPut("{id}")] // padrão REST Personalizando a rota para ser passado o parametro id na rota para atualização do usuário
        public async Task<ActionResult<Usuario>> AtualizarUsuario([FromBody] Usuario usuario, Guid id)
        {
            usuario.Id = id;
            Usuario usuarioAtualizado = await _usuarioRepositorio.Atualizar(usuario, id);

            return Ok(usuarioAtualizado); // retorna o código 200
        }

        [HttpDelete("{id}")] // padrão REST Personalizando a rota para ser passado o parametro id na rota para remover o usuário
        public async Task<ActionResult<Usuario>> DeletarUsuario(Guid id)
        {
            bool usuarioStatusRemovido= await _usuarioRepositorio.Apagar(id);

            return Ok(usuarioStatusRemovido);
        }

    }
}
