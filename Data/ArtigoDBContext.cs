using blog_aspAPI.Model;
using BlogAPI.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data

{
    public class ArtigoDBContext : DbContext 
    {
        public ArtigoDBContext(DbContextOptions<ArtigoDBContext> options) 
            : base(options)
        {
        }
        public DbSet<ArtigoModel> Artigos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtigoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
