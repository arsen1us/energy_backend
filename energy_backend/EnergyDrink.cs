using System;
using System.Collections.Generic;

namespace energy_backend;

public partial class EnergyDrink
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Flavor { get; set; } = null!;

    public int CoffeineCount { get; set; }

    public int SugarCount { get; set; }

    public double Size { get; set; }

    public string Ingridients { get; set; } = null!;

    public string NutritionInfo { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    public int? Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<EnergyDrinkPhoto> EnergyDrinkPhotos { get; set; } = new List<EnergyDrinkPhoto>();
}
