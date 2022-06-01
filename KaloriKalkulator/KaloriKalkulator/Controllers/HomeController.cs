using Microsoft.AspNetCore.Mvc;

namespace KaloriKalkulator.Controllers
{
    public class HomeController : Controller
    {

        FoodContext dx = new FoodContext();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Empty = true;
            return View();
        }

        [HttpGet]
        public ActionResult AddItem ()
        {
            return View(new Food());
        }

        [HttpPost]
        public ActionResult AddItem (string Item, string Calories)
        {
            if (Item == null || Calories == null)
            {
                ViewBag.IsString = "Det er tomme felt: Fyll inn informasjon";
            } else {
                if (int.TryParse(Calories, out int a) && !Exists(Item.ToLower())) //Sjekker om Calories er kun tall
                {
                    Food food = new Food();
                    food.Item = Item.ToLower();
                    food.Calories = int.Parse(Calories);
                    dx.Add(food);
                    dx.SaveChanges();
                    ViewBag.IsString = "Lagt til vare!";
                }
                else
                {
                    ViewBag.IsString = "Feil format: Skriv inn tall";
                }
            }
            return View("AddItem");
        }

        [HttpGet]
        public ActionResult SearchItem()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult SearchItem(string Search)
        {
            ViewBag.Empty = false;
            List<Food> foodList = dx.Foods.Where(s => s.Item.StartsWith(Search)).ToList();

            return View(foodList);
        }


        /*
        * Checks if item exists in database
        */
        public bool Exists (string Item)
        {
            return (dx.Foods.Where(s => s.Item.Equals(Item)).Any());
        }

    }
}
