using Intergado.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intergado.Data.Mappings
{
    public class AnimalMapping : IEntityTypeConfiguration<AnimalEntity>
    {
        public void Configure(EntityTypeBuilder<AnimalEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Identificador)
                   .IsRequired()
                   .HasColumnType("BIGINT")
                   .HasMaxLength(15);

            builder.ToTable("Animais");
        }
    }
}