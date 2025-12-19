using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Complement
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public decimal Prix { get; set; }

    public string? Image { get; set; }

    public bool? Actif { get; set; }

    public virtual ICollection<MenuComplement> MenuComplements { get; set; } = new List<MenuComplement>();
}
