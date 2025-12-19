using System;
using System.Collections.Generic;

namespace aspnet_client.Models;

public partial class MenuBurger
{
    public int Id { get; set; }

    public int? MenuId { get; set; }

    public int? BurgerId { get; set; }

    public virtual Burger? Burger { get; set; }

    public virtual Menu? Menu { get; set; }
}
