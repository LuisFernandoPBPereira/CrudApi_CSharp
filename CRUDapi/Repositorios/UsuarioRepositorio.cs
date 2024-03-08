using CRUDapi.Data;
using CRUDapi.Models;
using CRUDapi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUDapi.Repositorios
{
    //UsuarioRepositorio herda IUsuarioRepositorio
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        //Criamos uma variável de contexto
        private readonly SistemaDeTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }
        //Método Adicionar, que aguarda o recebimento do usuário para salvar no banco
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        //Método Apagar, que aguarda a requisição de busca por ID para poder fazer a deleção
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        //Método Atualizar, que aguarda a busca pelo ID para fazer a alteração
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        //Método BuscarPorId, que através do ID recebido, faz requisição no banco para mostrar a busca
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Método BuscarTodosUsuarios, que lista todos os usuários do banco
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
