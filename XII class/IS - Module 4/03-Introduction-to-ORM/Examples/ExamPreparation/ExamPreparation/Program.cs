
using ExamPreparation.Data;
using ExamPreparation.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new AppDbContext();

            //AddNewGenre(dbContext, "Another Genre");
            //UpdateGenre(dbContext, "NotExisting Genre", "ExistingGenre");
            //DeleteGenre(dbContext, 6);

            //var allGenres = GetAllGenres(dbContext);

            List<Book> books = GetAllBooks(dbContext);

            // обхождане на колекция от данни
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, {book.YearPublished} - {book.Author.Name} ({book.Genre.Name})");
            }
        }

        private static void UpdateGenre(AppDbContext ctx, string oldName, string newName)
        {
            Genre? genre = ctx.Genres.FirstOrDefault(g => g.Name == oldName);
            if(genre is null)
            {
                Console.WriteLine($"Genre {oldName} was not found.");
                return;
            }

            genre.Name = newName;
            ctx.Genres.Update(genre);
            ctx.SaveChanges();
        }

        private static void AddNewGenre(AppDbContext ctx, string name)
        {
            Genre newGenre = new Genre();
            newGenre.Name = name;
            ctx.Genres.Add(newGenre);
            ctx.SaveChanges();
        }

        private static List<Genre> GetAllGenres(AppDbContext ctx)
        {
            var genres = ctx.Genres
                //.OrderByDescending(g => g.Name)
                //.ThenBy(g => g.Id)
                .ToList();

            return genres;
        }

        private static void DeleteGenre(AppDbContext ctx, int genreId)
        {
            var genre = ctx.Genres.Find(genreId);
            if (genre is null) return;

            ctx.Genres.Remove(genre);
            ctx.SaveChanges();
        }

        private static List<Book> GetAllBooksSinceYear(AppDbContext ctx, int year)
        {
            var booksSinceYear = ctx.Books
                .Where(b => b.YearPublished > year)
                .Include(b => b.Author)
                .OrderByDescending(b => b.YearPublished)
                .ToList();

            return booksSinceYear;
        }

        private static List<Book> GetAllBooks(AppDbContext ctx)
        {
            var books = ctx.Books
                .Include(b =>b.Author)
                .Include(b => b.Genre)
                .ToList();

            return books;
        }
    }
}
