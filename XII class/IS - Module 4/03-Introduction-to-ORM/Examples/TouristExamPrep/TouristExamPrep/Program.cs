using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristExamPrep.Data;
using TouristExamPrep.Data.Models;

namespace TouristExamPrep
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AppDbContext dbContext = new AppDbContext();

            //CreateHotel(dbContext, "Ahmed Palace", 3);
            //UpdateHotel(dbContext, 41, "ahmed - grand hotel");

            //DeleteHotel(dbContext, 41);

            //List<TouristInfo> touristsInfo = GetAllTouristsInfo(dbContext);

            //var hotels = GetAllHotels(dbContext);

            if(dbContext.Hotels.Any(h => h.Name.Length == 4))
            {
                Console.WriteLine("There is at least one hotel 10 symbols long.");
            }

            //foreach (var ti in touristsInfo)
            //{
            //    Console.WriteLine($"{ti.Name}, {ti.PhoneNumber}");
            //}
        }

        // Delete
        private static void DeleteHotel(AppDbContext context, int id)
        {
            var hotelForDeletion = context.Hotels.Find(id);
            if(hotelForDeletion is null)
            {
                Console.WriteLine($"Hotel with id:{id} was not found.");
                return;
            }
            context.Hotels.Remove(hotelForDeletion);
            context.SaveChanges();
        }

        // Create
        private static void CreateHotel(AppDbContext context, string name, int destId)
        {
            Hotel newHotel = new Hotel();
            newHotel.Name = name;
            newHotel.DestinationId = destId;

            context.Hotels.Add(newHotel);
            context.SaveChanges();
        }

        // Update
        private static void UpdateHotel(AppDbContext context, int hotelId, string newName)
        {
            var hotelForUpdate = context.Hotels.Find(hotelId);
            if(hotelForUpdate is null)
            {
                Console.WriteLine($"Hotel with id:{hotelId} was not found.");
                return;
            }

            hotelForUpdate.Name = newName;
            context.Hotels.Update(hotelForUpdate);
            context.SaveChanges();
        }

        // Read
        private static List<Hotel> GetAllHotels(AppDbContext context)
        {
            var allHotels = context.Hotels
                //.Where(h => h.Name.StartsWith("A"))
                //.Include(h => h.Destination)
                //.Where(h => h.Destination.Name.StartsWith("L"))
                //.OrderByDescending(h => h.Name)
                //.Take(3)
                .ToList();

            return allHotels;
        }

        private static List<TouristInfo> GetAllTouristsInfo(AppDbContext ctx)
        {
            return ctx.Tourists
                .Select(t => new TouristInfo()
                {
                    Name = t.Name,
                    PhoneNumber = t.PhoneNumber
                })
                .ToList();
        }
    }
}
