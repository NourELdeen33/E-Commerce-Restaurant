namespace E_Commerce.ViewModels
{
    public class AddIngerdientViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
    }
}
