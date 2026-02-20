using System;
using System.Collections.Generic;

namespace TouristExamPrep.Data.Models;

public partial class Tourist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public int CountryId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Country Country { get; set; } = null!;
}
