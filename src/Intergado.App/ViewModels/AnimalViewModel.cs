using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Intergado.App.ViewModels
{
    public class AnimalViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Somente valores numéricos")]
        [MaxLength(15, ErrorMessage = "Número máximo de caracteres é 15")]
        public string Identificador { get; set; }

        [DisplayName("Fazenda")]
        public long FazendaId { get; set; }

        public FazendaViewModel Fazenda { get; set; }

        public List<FazendaViewModel> Fazendas { get; set; }
    }
}