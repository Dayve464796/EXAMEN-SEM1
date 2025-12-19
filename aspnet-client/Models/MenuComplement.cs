using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class MenuComplement
{
    public int Id { get; set; }

    public int? MenuId { get; set; }

    public int? ComplementId { get; set; }

    public virtual Complement? Complement { get; set; }

    public virtual Menu? Menu { get; set; }
}
