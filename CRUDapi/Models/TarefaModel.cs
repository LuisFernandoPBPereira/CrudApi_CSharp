using CRUDapi.Enums;

namespace CRUDapi.Models
{
    //Estrutura da Tarefa
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
