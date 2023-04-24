using BeatleBug.Models;
using System.Security.Claims;

namespace BeatleBug.Services
{
    public interface IClaimsService
    {
        Task<List<Claim>> GetUserClaimsAsync(ApplicationUser user);
    }
}
