using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data.Models
{
    [Comment("Shopping List Product")]
    public class Product
    {
        [Key]
        [Comment("Product Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
