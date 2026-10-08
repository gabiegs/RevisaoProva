using System.ComponentModel.DataAnnotations;

namespace RevisaoProva.Models
{
    public class Peneira
    {
        [Required]
        public string CPF { get; set; }

        [Required]
        public bool Aprovado { get; set; }
    }
}
