using System;
using System.Collections.Generic;

namespace ExamPreparation.Data.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ContactId { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Contact? Contact { get; set; }
}
