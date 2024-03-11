using CRUDapi.Integracao.Interfaces;
using CRUDapi.Integracao.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViacepIntegracao _viacepIntegracao;
        public CepController(IViacepIntegracao viacepIntegracao)
        {
            _viacepIntegracao = viacepIntegracao;
        }
        [HttpGet("{cep}")]
        public async Task<ActionResult<ViacepResponse>> ListarDadosEndereco(string cep)
        {
            var responseData = await _viacepIntegracao.ObterDadosViacep(cep);

            if(responseData == null)
            {
                return BadRequest("Cep não encontrado!");
            }

            return Ok(responseData);
        }
    }
}
