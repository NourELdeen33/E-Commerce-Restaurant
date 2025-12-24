using E_Commerce.Attribute;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.ViewModels
{
    public class AddEditViewModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int[] IngerdientsId { get; set; }

        public int Stock { get; set; }

      }
    

}
