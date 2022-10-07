namespace la_mia_pizzeria_post.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pizza> Pizze { get; set; }
    }
}
