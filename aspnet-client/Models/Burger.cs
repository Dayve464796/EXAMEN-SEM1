using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Burger
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public decimal Prix { get; set; }

    public string? Image { get; set; }

    public bool? Actif { get; set; }

    public virtual ICollection<CommandeBurger> CommandeBurgers { get; set; } = new List<CommandeBurger>();

    public virtual ICollection<MenuBurger> MenuBurgers { get; set; } = new List<MenuBurger>();
}
