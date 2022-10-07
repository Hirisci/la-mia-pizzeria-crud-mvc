using la_mia_pizzeria_post.Data;
using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace la_mia_pizzeria_model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PizzeDbContext _db;

        public HomeController(ILogger<HomeController> logger, PizzeDbContext db)
        {
            _db = db;
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Menu()
        {
            List<Pizza> pizze = _db.Pizze.ToList();
            return View(pizze);
        }
        
        public IActionResult Create()
        {
            PizzaCategory pizzaCategory = new PizzaCategory();
            pizzaCategory.Pizza = new Pizza();
            pizzaCategory.Categories = _db.Categories.ToList();
            return View(pizzaCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategory pizzaCategory)
        {
            if (!ModelState.IsValid)
            {
                pizzaCategory.Categories = _db.Categories.ToList();
                return View(pizzaCategory);
            }
            
            _db.Pizze.Add(pizzaCategory.Pizza);
            _db.SaveChanges();
            return RedirectToAction(nameof(Menu));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pizza? pizza = _db.Pizze.First(x => x.Id == id);

            if(pizza is null)
            {
                return NotFound("Pizza non disponibile");
            }

            PizzaCategory pizzaCategory = new PizzaCategory();
            pizzaCategory.Pizza = pizza;
            pizzaCategory.Categories = _db.Categories.ToList();
            return View(pizzaCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , PizzaCategory pizzaCategory)
        {
            if (!ModelState.IsValid)
            {
                pizzaCategory.Categories = _db.Categories.ToList();
                return View(pizzaCategory);
            }

            Pizza? pizza = _db.Pizze.First(x => x.Id == id);

            if (pizza is null)
            {
                return NotFound("Pizza non disponibile");
            }

            pizza.Name = pizzaCategory.Pizza.Name;
            pizza.Amount = pizzaCategory.Pizza.Amount;
            pizza.Descrition = pizzaCategory.Pizza.Descrition;
            pizza.Img = pizzaCategory.Pizza.Img;
            pizza.CategoryId = pizzaCategory.Pizza.CategoryId;

            _db.SaveChanges();

            return RedirectToAction(nameof(Menu));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Pizza? pizza = _db.Pizze.First(x => x.Id == id);
            if (pizza is null)
            {
                return NotFound("Pizza non disponibile");
            }
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Pizza? pizza = _db.Pizze.First(x => x.Id == id);
            if (pizza is null)
            {
                return NotFound("Pizza non disponibile");
            }

            _db.Pizze.Remove(pizza);
            _db.SaveChanges();

            return RedirectToAction(nameof(Menu));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}