namespace la_mia_pizzeria_post.Models
{
    public class PizzaCategory
    {
        public Pizza Pizza { get; set; }

        public List<Category> Categories { get; set; }


        public PizzaCategory()
        {
            Categories = new List<Category>();
        }
    }

  
}
