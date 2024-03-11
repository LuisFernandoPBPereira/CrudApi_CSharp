using CRUDapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDapi.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        //Mapeamos os usuários para o banco de dados
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            //A partir daqui, é mapeada a relação entre usuário e tarefa
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Usuario);
        }
    }
}
