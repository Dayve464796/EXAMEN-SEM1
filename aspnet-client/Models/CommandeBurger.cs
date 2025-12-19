using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class CommandeBurger
{
    public int Id { get; set; }

    public int? CommandeId { get; set; }

    public int? BurgerId { get; set; }

    public int? Quantite { get; set; }

    public virtual Burger? Burger { get; set; }

    public virtual Commande? Commande { get; set; }
}
