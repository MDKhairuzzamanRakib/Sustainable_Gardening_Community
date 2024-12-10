using Microsoft.AspNetCore.Identity;

namespace Sustainable_Gardening_Community.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
