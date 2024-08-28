using blog_aspAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Map
{
    public class ArtigoMap : IEntityTypeConfiguration<ArtigoModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ArtigoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Artigo).IsRequired();
            builder.Property(x => x.Autor).IsRequired().HasMaxLength(45);
        }
    }
}
