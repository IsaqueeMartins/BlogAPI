using blog_aspAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_aspAPI.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtigoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ArtigoModel>> BuscaArtigo()
        {
            return Ok();
        }
    }
}
