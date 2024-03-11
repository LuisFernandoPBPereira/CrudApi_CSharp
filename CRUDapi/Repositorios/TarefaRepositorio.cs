using CRUDapi.Data;
using CRUDapi.Models;
using CRUDapi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUDapi.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        //Criamos uma variável de contexto
        private readonly SistemaDeTarefasDBContext _dbContext;
        public TarefaRepositorio(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }
        //Método Adicionar, que aguarda o recebimento da tarefa para salvar no banco
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        //Método Apagar, que aguarda a requisição de busca por ID para poder fazer a deleção
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        //Método Atualizar, que aguarda a busca pelo ID para fazer a alteração
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        //Método BuscarPorId, que através do ID recebido, faz requisição no banco para mostrar a busca
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //Método BuscarTodasTarefas, que lista todas as tarefas do banco
        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }
    }
}