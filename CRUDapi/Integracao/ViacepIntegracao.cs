using CRUDapi.Integracao.Interfaces;
using CRUDapi.Integracao.Refit;
using CRUDapi.Integracao.Response;

namespace CRUDapi.Integracao
{
    public class ViacepIntegracao : IViacepIntegracao
    {
        private readonly IViacepIntegracaoRefit _viacepIntegracaoRefit;
        public ViacepIntegracao(IViacepIntegracaoRefit viacepIntegracaoRefit)
        {
            _viacepIntegracaoRefit = viacepIntegracaoRefit;
        }
        public async Task<ViacepResponse> ObterDadosViacep(string cep)
        {
            var responseData = await _viacepIntegracaoRefit.ObterDadosViacep(cep);

            if(responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
