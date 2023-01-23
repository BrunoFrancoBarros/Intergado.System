namespace Intergado.Business.Model
{
    public class FazendaEntity : EntityBase
    {
        public string Descricao { get; set; }

        public List<AnimalEntity> Animais { get; set; }
    }
}