using BeatleBug.Models.Dtos;

namespace BeatleBug.Client.Web.Services.Contracts
{
    public interface ITokenService
    {
        Task<TokenDto> GetToken();
        Task RemoveToken();
        Task SetToken(TokenDto tokenDto);
    }
}
