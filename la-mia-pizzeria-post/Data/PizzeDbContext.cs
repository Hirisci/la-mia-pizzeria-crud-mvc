using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_post.Models;

namespace la_mia_pizzeria_post.Data
{
    public class PizzeDbContext : DbContext
    {
        public PizzeDbContext(DbContextOptions<PizzeDbContext> options) : base(options)
        {

        }

        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
