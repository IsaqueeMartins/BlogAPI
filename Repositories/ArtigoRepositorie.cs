using blog_aspAPI.Model;
using BlogAPI.Data;
using BlogAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Crmf;

namespace BlogAPI.Repositories
{
    public class ArtigoRepositorie : IArtigosRepositorie
    {
        private readonly ArtigoDBContext _context;
        public ArtigoRepositorie(ArtigoDBContext artigoDBContext) 
        {
            _context = artigoDBContext;
        }
        public async Task<IEnumerable<ArtigoModel>> BuscarPorTitulo(string titulo)
        {
            var artigos = await _context.Artigos
                .Where(a => a.Titulo.Contains(titulo))
                .Select(a => new ArtigoModel
                {
                    Id = a.Id,
                    Titulo = a.Titulo,
                    Artigo = a.Artigo,
                    Autor = a.Autor,
                    Data_Escrita = a.Data_Escrita,
                    Ultima_Atualizacao = a.Ultima_Atualizacao
                })
            .ToListAsync();

            return artigos;
            }
        
        public async Task<ArtigoModel> BuscarArtigoPorId(int id)
        {
            return await _context.Artigos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ArtigoModel>> BuscarArtigos()
        {
            return await _context.Artigos.ToListAsync();
        }
        public async Task<ArtigoModel> Adicionar(ArtigoModel artigo)
        {
           await _context.Artigos.AddAsync(artigo);
           await _context.SaveChangesAsync();

            return artigo;
        }
        public async Task<ArtigoModel> Atualizar(ArtigoModel artigo, int id)
        {
            ArtigoModel artigoPorId = await BuscarArtigoPorId(id);

            if (artigoPorId == null)
            {
                throw new Exception($"Artigo com ID {id} não foi encontrato");
            }
            
            artigoPorId.Artigo = artigo.Titulo;
            artigoPorId.Artigo = artigo.Artigo;
            artigoPorId.Artigo = artigo.Autor;

            _context.Artigos.Update(artigoPorId);
            await _context.SaveChangesAsync();

            return artigoPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            ArtigoModel artigoPorId = await BuscarArtigoPorId(id);

            if (artigoPorId == null)
            {
                throw new Exception($"Artigo com ID {id} não foi encontrato");
            }

            _context.Artigos.Remove(artigoPorId);
            await _context.SaveChangesAsync();
           
            return true;
        }     
    }
}
