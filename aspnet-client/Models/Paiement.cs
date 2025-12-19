using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Paiement
{
    public int Id { get; set; }

    public int? CommandeId { get; set; }

    public decimal? Montant { get; set; }

    public DateTime? DatePaiement { get; set; }

    public string? Mode { get; set; }

    public virtual Commande? Commande { get; set; }
}
