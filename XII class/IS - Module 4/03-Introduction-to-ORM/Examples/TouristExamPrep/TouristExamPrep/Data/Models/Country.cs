using System;
using System.Collections.Generic;

namespace TouristExamPrep.Data.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
