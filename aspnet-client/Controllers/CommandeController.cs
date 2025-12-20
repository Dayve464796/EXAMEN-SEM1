using aspnet_client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace aspnet_client.Controllers
{
    public class CommandeController : Controller
    {
        private const string PANIER_KEY = "PANIER";

        // ======================
        // AJOUT AU PANIER
        // ======================

        public IActionResult AjouterBurger(int id)
        {
            var panier = GetPanier();
            panier.Add($"Burger #{id}");
            SavePanier(panier);

            TempData["Message"] = "Burger ajouté au panier";
            return RedirectToAction("Panier");
        }

        public IActionResult AjouterMenu(int id)
        {
            var panier = GetPanier();
            panier.Add($"Menu #{id}");
            SavePanier(panier);

            TempData["Message"] = "Menu ajouté au panier";
            return RedirectToAction("Panier");
        }

        // ======================
        // PANIER
        // ======================

        public IActionResult Panier()
        {
            var panier = GetPanier();
            return View(panier);
        }

        // ======================
        // PAIEMENT (SIMULÉ)
        // ======================

        public IActionResult Paiement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValiderPaiement(string mode)
        {
            TempData["Message"] = $"Paiement effectué par {mode}";
            HttpContext.Session.Remove(PANIER_KEY);
            return RedirectToAction("Panier");
        }

        // ======================
        // UTILS SESSION
        // ======================

        private List<string> GetPanier()
        {
            var data = HttpContext.Session.GetString(PANIER_KEY);
            return data == null
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(data)!;
        }

        private void SavePanier(List<string> panier)
        {
            HttpContext.Session.SetString(PANIER_KEY, JsonSerializer.Serialize(panier));
        }

        // Afficher le choix des compléments pour un burger
        public IActionResult ChoixComplement(int id)
        {
            // On peut stocker l'id du burger en session si besoin
            HttpContext.Session.SetInt32("BURGER_ID", id);

            return View();
        }

        [HttpPost]
public IActionResult ValiderComplements(List<string> complements)
{
    var panier = GetPanier();

    var burgerId = HttpContext.Session.GetInt32("BURGER_ID");

    var recap = $"Burger #{burgerId}";

    if (complements != null && complements.Any())
    {
        recap += " + " + string.Join(", ", complements);
    }

    panier.Add(recap);
    SavePanier(panier);

    TempData["Message"] = "Burger et compléments ajoutés au panier";

    return RedirectToAction("Panier");
}

   public IActionResult ChoixTypeCommande()
{
    return View();
}

[HttpPost]
public IActionResult ValiderTypeCommande(string typeCommande)
{
    HttpContext.Session.SetString("TYPE_COMMANDE", typeCommande);
    return RedirectToAction("Panier");
}

    


public IActionResult TypeCommande()
{
    return View();
}

[HttpPost]
public IActionResult ValiderType(string type)
{
    HttpContext.Session.SetString("TYPE_COMMANDE", type);
    return RedirectToAction("Paiement"); 
}

}
}
