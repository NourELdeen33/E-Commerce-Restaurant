namespace E_Commerce.ViewModels
{
    public class ChangePasswrodViewModel
    {

        [Required(ErrorMessage = "Email Addresse Is Required")]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }= string.Empty;

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }=string.Empty;


    }
}
