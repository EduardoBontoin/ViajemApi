
using System.ComponentModel.DataAnnotations;

namespace ApiViajem.Models
{
    public class Destino
    {
        [Required]
        public int Id { get; set; }
        public string Foto1 { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Foto2 { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(600,ErrorMessage = "Tamanho maximo deve ser de 600 Caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(160,ErrorMessage = "Tamanho maximo deve ser de 160 caracteres")]
        public string Meta { get; set; }
        public string? Descritivo { get; set; }
    }
}
