using Microsoft.AspNetCore.Identity;

namespace BeatleBug.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name)
        {
            Name = name;
        }
    }
}
