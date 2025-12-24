namespace E_Commerce.Attribute
{
    public class AllowedSizeAttribute:ValidationAttribute
    {
        private const int _maxSizeInMB = 1;
        private const int _maxSizeInBytes = _maxSizeInMB * 1024*1024;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            var file = value as IFormFile;
            if (file is not null)
            {
                if (file.Length < _maxSizeInBytes)
                    return ValidationResult.Success;
            }
            return new ValidationResult($"Size Can't be Over {_maxSizeInMB} MB");
        }
    }
}
