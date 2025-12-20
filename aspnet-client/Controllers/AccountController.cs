using Microsoft.AspNetCore.Mvc;

namespace aspnet_client.Controllers
{
    public class AccountController : Controller
    {
     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
           
            HttpContext.Session.SetString("CLIENT", email);
            return RedirectToAction("Index", "Home");
        }

                public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string nom, string telephone, string email)
        {
           
            HttpContext.Session.SetString("CLIENT", email);
            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CLIENT");
            return RedirectToAction("Index", "Home");
        }
    }
}