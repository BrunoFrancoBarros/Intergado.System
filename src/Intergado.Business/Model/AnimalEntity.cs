namespace Intergado.Business.Model
{
    public class AnimalEntity : EntityBase
    {
        public string Identificador { get; set; }

        public long FazendaId { get; set; }

        public FazendaEntity Fazenda { get; set; }
    }
}