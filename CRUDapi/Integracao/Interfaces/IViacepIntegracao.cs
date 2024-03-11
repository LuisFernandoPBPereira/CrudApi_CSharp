using CRUDapi.Integracao.Response;

namespace CRUDapi.Integracao.Interfaces
{
    public interface IViacepIntegracao
    {
        Task<ViacepResponse> ObterDadosViacep(string cep);
    }
}
