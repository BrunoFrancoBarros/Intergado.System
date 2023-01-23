using Intergado.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intergado.Data.Mappings
{
    public class FazendaMapping : IEntityTypeConfiguration<FazendaEntity>
    {
        public void Configure(EntityTypeBuilder<FazendaEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            // 1:N => Fazenda : Animais
            builder.HasMany(a => a.Animais)
                   .WithOne(f => f.Fazenda)
                   .HasForeignKey(f => f.FazendaId);

            builder.ToTable("Fazendas");
        }
    }
}