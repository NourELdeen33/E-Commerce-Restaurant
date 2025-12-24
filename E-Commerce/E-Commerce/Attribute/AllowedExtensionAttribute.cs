namespace E_Commerce.Attribute
{
    public class AllowedExtensionAttribute:ValidationAttribute
    {
      


        private const string Extension = ".jpeg,.jpg,.png";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            var cover = value as IFormFile;
            if (cover != null)
            {
                var extension = Path.GetExtension(cover.FileName);
                var isAllowed = Extension.Split(separator: ',')
                    .Contains(extension, StringComparer.OrdinalIgnoreCase);
                if (isAllowed)
                    return ValidationResult.Success;


            }
            return new ValidationResult($"Only {Extension} is Allowed");

        }
    }
}
