using blog_aspAPI.Model;
using BlogAPI.Repositories;
using BlogAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace blog_aspAPI.Controler
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ArtigoController : ControllerBase
    {
        private readonly IArtigosRepositorie _artigosRepositorie;
        public ArtigoController(IArtigosRepositorie artigosRepositorie)
        {
            _artigosRepositorie = artigosRepositorie;
        }
        [HttpGet]
        public async Task<ActionResult<List<ArtigoModel>>> BuscaArtigo()
        {
           List<ArtigoModel> artigos = await _artigosRepositorie.BuscarArtigos();
            return Ok(artigos);
        }

        [Route("id={id}")]
        [HttpGet]
        public async Task<ActionResult<ArtigoModel>> BuscarPorId(int id)
        {
            ArtigoModel artigo = await _artigosRepositorie.BuscarArtigoPorId(id);
            return Ok(artigo);
        }

        [Route("titulo_like={titulo}")]
        [HttpGet]
        public async Task<ActionResult<ArtigoModel>> BuscarTitulo(string titulo)
        {
            ArtigoModel artigo = await _artigosRepositorie.BuscarPorTitulo(titulo);
            return Ok(artigo);
        }

        [HttpPost]
        public async Task<ActionResult<ArtigoModel>> Adicionar([FromBody] ArtigoModel artigoModel)
        {
            ArtigoModel artigo = await _artigosRepositorie.Adicionar(artigoModel);
            return Ok(artigo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArtigoModel>> Atualizar([FromBody] ArtigoModel artigoModel, int id)
        {
            artigoModel.Id = id;
            ArtigoModel artigo = await _artigosRepositorie.Atualizar(artigoModel, id);
            return Ok(artigo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _artigosRepositorie.Apagar(id);
            return Ok(apagado);
        }

    }
}
