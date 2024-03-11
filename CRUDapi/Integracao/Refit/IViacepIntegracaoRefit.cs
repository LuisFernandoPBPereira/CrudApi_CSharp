using CRUDapi.Integracao.Response;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Refit;

namespace CRUDapi.Integracao.Refit
{
    public interface IViacepIntegracaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViacepResponse>> ObterDadosViacep(string cep);
    }
}
