using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }=string.Empty;
        public string FullName{ get; set; }=string.Empty;
        public ICollection<Order>? Orders {  get; set; }
    }
}
