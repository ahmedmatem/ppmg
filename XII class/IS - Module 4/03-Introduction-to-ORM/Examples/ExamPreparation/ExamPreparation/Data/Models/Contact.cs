using System;
using System.Collections.Generic;

namespace ExamPreparation.Data.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PostAddress { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();
}
