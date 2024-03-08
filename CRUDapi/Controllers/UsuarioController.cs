using CRUDapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TarefaModel>> BuscarTodosUsuarios()
        {
            return Ok();
        }
    }
}
