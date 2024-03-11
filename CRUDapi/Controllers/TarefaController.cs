using CRUDapi.Models;
using CRUDapi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        //Criamos uma variável do tipo ITarefaRepositorio globalmente
        private readonly ITarefaRepositorio _tarefaRepositorio;

        //Assinamos o contrato no construtor
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        //Método GET para buscar todas as tarefas em uma Lista do tipo TarefaModel de forma assíncrona
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }
        //Método GET com id para buscar uma tarefa pelo ID dele de forma assíncrona
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        //Método POST com requisição pelo body para a criação da tarefa de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        //Método PUT com requisição pelo body para a atualização da tarefa de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        //Método DELETE que busca a tarefa pelo ID para deletar a tarefa
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            bool apagado = await _tarefaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}