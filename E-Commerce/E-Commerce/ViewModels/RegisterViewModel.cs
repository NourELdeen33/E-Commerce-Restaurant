namespace E_Commerce.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Your Name Is Required")]
        [Display(Name ="Full Name")]
        [MaxLength(50)]
        [MinLength(3)]
        public string FullName { get; set; }=string.Empty;

        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set;} = string.Empty;
    }
}
