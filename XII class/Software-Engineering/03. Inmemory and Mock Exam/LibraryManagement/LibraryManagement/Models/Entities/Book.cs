namespace LibraryManagement.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Isbn { get; set; } = null!;

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
