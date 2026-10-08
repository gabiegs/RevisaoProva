using System.ComponentModel.DataAnnotations;

namespace RevisaoProva.Models
{
    public class Jogador
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public string Posicao { get; set; }

        public bool? Aprovado { get; set; }
    }
}
