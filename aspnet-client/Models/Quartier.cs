using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class Quartier
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public int? ZoneId { get; set; }

    public virtual Zone? Zone { get; set; }
}
