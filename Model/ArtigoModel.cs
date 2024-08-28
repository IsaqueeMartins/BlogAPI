namespace blog_aspAPI.Model
{
    public class ArtigoModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Artigo { get; set; }
        public string Autor { get; set; }
        public DateTime Data_Escrita { get; set; }
        public DateTime Ultima_Atualizacao { get; set; }
    }
}
