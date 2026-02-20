using System;
using System.Collections.Generic;

namespace TouristExamPrep.Data.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DestinationId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Destination? Destination { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
