using System;
using System.Collections.Generic;

namespace GroceryStore2.Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public string UnitType { get; set; } = null!;
}
