using System;
using System.Collections.Generic;

namespace energy_backend;

public partial class EnergyDrinkPhoto
{
    public string Id { get; set; } = null!;

    public string? EnergyDrinkId { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual EnergyDrink? EnergyDrink { get; set; }
}
