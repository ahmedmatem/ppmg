using System;
using System.Collections.Generic;

namespace TouristExamPrep.Data.Models;

public partial class Booking
{
    public int Id { get; set; }

    public DateTime ArrivalDate { get; set; }

    public DateTime DepartureDate { get; set; }

    public int AdultCount { get; set; }

    public int ChildrenCount { get; set; }

    public int? TouristId { get; set; }

    public int? HotelId { get; set; }

    public int RoomId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual Tourist? Tourist { get; set; }
}
