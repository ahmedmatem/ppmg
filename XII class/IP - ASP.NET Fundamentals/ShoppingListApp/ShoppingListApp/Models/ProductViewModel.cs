using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Display(Name = "Product Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Field {0} must be between {2} and {1} symbols")]
        public string Name { get; set; } = string.Empty;
    }
}
