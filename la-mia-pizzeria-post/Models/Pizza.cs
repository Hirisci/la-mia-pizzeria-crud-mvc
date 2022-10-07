using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_post.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public string Img { get; set; }

        [StringLength(50, ErrorMessage = "Il nome della pizza non puó superare i {1} caratteri")]
        [Required]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Il nome della pizza non puó superare i {1} caratteri")]
        public string Descrition { get; set; }

        [Required]
        [Range(0, 999.99, ErrorMessage = "Il prezzo della pizza deve essere un valore tra {1} e {2}")]
        public float Amount { get; set; }

        public int CategoryId { get; set; } 
        public Category? Category { get; set; }

    }
}
