using System.ComponentModel.DataAnnotations;

namespace ApiViajem.Models
{
    public class Depoimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Imagem { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(5000,ErrorMessage ="Tamanho maximo 5000 caracteres")]
        public string Comentario { get; set; }
        [Required(ErrorMessage ="Campo Obrigatorio")]
        public string Nome { get; set; }


    }
}
