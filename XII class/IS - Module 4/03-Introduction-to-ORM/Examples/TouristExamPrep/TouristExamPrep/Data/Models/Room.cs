using System;
using System.Collections.Generic;

namespace TouristExamPrep.Data.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public decimal Price { get; set; }

    public int BedCount { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
