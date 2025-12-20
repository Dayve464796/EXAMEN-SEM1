using Microsoft.AspNetCore.Mvc;
using aspnet_client.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_client.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ======================
        // CATALOGUE BURGERS
        // ======================
        public IActionResult Burgers()
        {
            var burgers = _context.Burgers.ToList();
            return View(burgers);
        }

        // Détails d’un burger
        public IActionResult BurgerDetails(int id)
        {
            var burger = _context.Burgers.FirstOrDefault(b => b.Id == id);
            if (burger == null)
                return NotFound();

            return View(burger);
        }

        // ======================
        // CATALOGUE MENUS
        // ======================
        public IActionResult Menus()
        {
           var menus = _context.Menus
            .Include(m => m.MenuBurgers)
                .ThenInclude(mb => mb.Burger)
            .Include(m => m.MenuComplements)
                .ThenInclude(mc => mc.Complement)
            .ToList();
            return View(menus);
        }

        // Détails d’un menu
        public IActionResult MenuDetails(int id)
        {
            var menu = _context.Menus.FirstOrDefault(m => m.Id == id);
            if (menu == null)
                return NotFound();

            return View(menu);
        }
    

    public IActionResult Index(string type)
{
    if (type == "burger")
        return RedirectToAction("Burgers");

    if (type == "menu")
        return RedirectToAction("Menus");

    return View();
}
    }
}
