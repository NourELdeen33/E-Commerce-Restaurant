using E_Commerce.Attribute;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.ViewModels
{
    public class EditProdcutViewModel : AddEditViewModel
    {
        public int Id { get; set; }

        public string? CurrentImage { get; set; }
        [AllowedExtension]
        [AllowedSize]
        public IFormFile? ProductImage { get; set; }
    }
}
