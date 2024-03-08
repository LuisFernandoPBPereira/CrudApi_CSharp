using CRUDapi.Data.Map;
using CRUDapi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDapi.Data
{
    public class SistemaDeTarefasDBContext : DbContext
    {
        /*
         * Criamos o construtor do contexto do banco, passando em seu parâmetro
         * as opções de contexto do banco de dados com o tipo do contexto,
         * e retornamos para a superclasse DbContext
        */
        public SistemaDeTarefasDBContext(DbContextOptions<SistemaDeTarefasDBContext> options)
            :base(options) { }

        //Configuramos as tabelas
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        
        //Passamos as configurações para modelar as tabelas com os mapas delas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
