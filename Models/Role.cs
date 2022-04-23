using Microsoft.AspNetCore.Identity;

namespace Magazyn.Models
{
    public class Role : IdentityRole<int>
    {
        public RoleValue RoleValue { get; set; }
    }
}
