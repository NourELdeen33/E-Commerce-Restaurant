namespace E_Commerce.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email Addresse Is Required")]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
    }
}
