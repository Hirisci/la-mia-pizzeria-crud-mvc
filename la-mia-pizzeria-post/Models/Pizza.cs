using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_post.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Img { get; set; }
        [StringLength(50, ErrorMessage = "Il nome della pizza non puó superare i {1} caratteri")]
        [Required]
        public string Name { get; set; }
        [StringLength(1000, ErrorMessage = "Il nome della pizza non puó superare i {1} caratteri")]
        [RegularExpression(@"(\w+\W){4,}\w+",
         ErrorMessage = "La descrizione deve avere piú di 5 parole")]
        public string Descrition { get; set; }
        [Required]
        [Range(0, 999.99, ErrorMessage = "Il prezzo della pizza deve essere un valore tra {1} e {2}")]
        public float Amount { get; set; }

    }
}
