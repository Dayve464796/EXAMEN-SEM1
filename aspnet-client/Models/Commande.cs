using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Commande
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public DateTime? DateCommande { get; set; }

    public string? Etat { get; set; }

    public string? TypeCommande { get; set; }

    public int? ZoneId { get; set; }

    public decimal? MontantTotal { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<CommandeBurger> CommandeBurgers { get; set; } = new List<CommandeBurger>();

    public virtual ICollection<CommandeMenu> CommandeMenus { get; set; } = new List<CommandeMenu>();

    public virtual Paiement? Paiement { get; set; }

    public virtual Zone? Zone { get; set; }
}
