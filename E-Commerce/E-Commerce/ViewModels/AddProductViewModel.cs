
using E_Commerce.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.ViewModels
{
    public class AddProductViewModel : AddEditViewModel
    {
        [AllowedExtension]
        [AllowedSize]
        public IFormFile ProductImage
        {
            get; set;
        }
    }
}
