using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Intergado.App.ViewModels
{
    public class FazendaViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo do campo são 200 caracteres")]
        [DisplayName("Descição da Fazenda")]
        public string Descricao { get; set; }

        public List<AnimalViewModel> Animais { get; set; }
    }
}