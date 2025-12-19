using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class CommandeMenu
{
    public int Id { get; set; }

    public int? CommandeId { get; set; }

    public int? MenuId { get; set; }

    public int? Quantite { get; set; }

    public virtual Commande? Commande { get; set; }

    public virtual Menu? Menu { get; set; }
}
