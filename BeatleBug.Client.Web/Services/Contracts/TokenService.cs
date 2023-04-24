using BeatleBug.Models.Dtos;
using Blazored.LocalStorage;

namespace BeatleBug.Client.Web.Services.Contracts
{
    public class TokenService : ITokenService
    {
        private readonly ILocalStorageService _localStorageService;

        public TokenService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task SetToken(TokenDto tokenDto)   
        {
            await _localStorageService.SetItemAsync("token", tokenDto);
        }

        public async Task<TokenDto> GetToken()
        {
            return await _localStorageService.GetItemAsync<TokenDto>("token");
        }

        public async Task RemoveToken()
        {
            await _localStorageService.RemoveItemAsync("token");
        }
    }
}
