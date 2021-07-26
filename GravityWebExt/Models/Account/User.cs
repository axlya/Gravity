using Microsoft.AspNetCore.Identity;

namespace GravityWebExt.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}