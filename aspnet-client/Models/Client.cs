using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
