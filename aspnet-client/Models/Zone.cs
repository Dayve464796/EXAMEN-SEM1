using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Zone
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public decimal? Prix { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    public virtual ICollection<Quartier> Quartiers { get; set; } = new List<Quartier>();
}
