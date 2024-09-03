using blog_aspAPI.Model;

namespace BlogAPI.Repositories.Interface
{
    public interface IArtigosRepositorie
    {
        Task<IEnumerable<ArtigoModel>> BuscarPorTitulo(string titulo);
        Task<ArtigoModel> BuscarArtigoPorId(int id);
        Task<List<ArtigoModel>> BuscarArtigos();
        Task<ArtigoModel> Adicionar(ArtigoModel artigo);
        Task<ArtigoModel> Atualizar(ArtigoModel artigo, int id);

        Task<bool> Apagar(int id);

    }
}
