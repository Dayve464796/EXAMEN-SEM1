using System;
using System.Collections.Generic;

namespace aspnet_client.Models
{
    public partial class Commande
    {
        // ======================
        // Colonnes Base de Données
        // ======================
        public int Id { get; set; }

        public int? ClientId { get; set; }

        public DateTime? DateCommande { get; set; }

        public string? Etat { get; set; }

        // sur_place | a_emporter | livraison
        public string? TypeCommande { get; set; }

        public int? ZoneId { get; set; }

        public decimal? MontantTotal { get; set; }

        // ======================
        // Relations
        // ======================
        public virtual Client? Client { get; set; }

        public virtual ICollection<CommandeBurger> CommandeBurgers { get; set; }
            = new List<CommandeBurger>();

        public virtual ICollection<CommandeMenu> CommandeMenus { get; set; }
            = new List<CommandeMenu>();

        public virtual Paiement? Paiement { get; set; }

        public virtual Zone? Zone { get; set; }

        // ======================
        // LOGIQUE MÉTIER (EXAMEN)
        // ======================

        /// <summary>
        /// Initialiser une nouvelle commande client
        /// </summary>
        public void InitialiserCommande(int clientId, string typeCommande)
        {
            ClientId = clientId;
            TypeCommande = typeCommande;
            DateCommande = DateTime.Now;
            Etat = "EN_COURS";
            MontantTotal = 0;
        }

        /// <summary>
        /// Ajouter un burger à la commande
        /// </summary>
        public void AjouterBurger(Burger burger, int quantite = 1)
        {
            if (burger == null) return;

            CommandeBurgers.Add(new CommandeBurger
            {
                BurgerId = burger.Id,
                Quantite = quantite
            });

            MontantTotal += burger.Prix * quantite;
        }

        /// <summary>
        /// Ajouter un menu à la commande
        /// </summary>
        public void AjouterMenu(Menu menu, decimal prixMenu)
        {
            if (menu == null) return;

            CommandeMenus.Add(new CommandeMenu
            {
                MenuId = menu.Id
            });

            MontantTotal += prixMenu;
        }

        /// <summary>
        /// Finaliser la commande (après paiement)
        /// </summary>
        public void ValiderCommande()
        {
            Etat = "VALIDEE";
        }

        /// <summary>
        /// Annuler la commande
        /// </summary>
        public void AnnulerCommande()
        {
            Etat = "ANNULEE";
        }
    }
}