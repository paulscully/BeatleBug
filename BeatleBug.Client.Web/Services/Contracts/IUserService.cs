using BeatleBug.Models.Dtos;

namespace BeatleBug.Client.Web.Services.Contracts
{
    public interface IUserService
    {
        Task<RegisterResponseDto> RegisterUser(RegisterDto registerDto);
        Task<LoginResponseDto> LoginUser(LoginDto loginDto);
        Task LogoutUser();
    }
}
