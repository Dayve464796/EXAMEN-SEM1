using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Image { get; set; }

    public bool? Actif { get; set; }

    public virtual ICollection<CommandeMenu> CommandeMenus { get; set; } = new List<CommandeMenu>();

    public virtual ICollection<MenuBurger> MenuBurgers { get; set; } = new List<MenuBurger>();

    public virtual ICollection<MenuComplement> MenuComplements { get; set; } = new List<MenuComplement>();
}
