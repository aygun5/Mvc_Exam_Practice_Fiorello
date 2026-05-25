using Microsoft.AspNetCore.Identity;

namespace MVC_Fiorella_All.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
