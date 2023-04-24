using BeatleBug.Models.Dtos;

namespace BeatleBug.Client.Web.Services.Contracts
{
    public class UserService : ClientApi, IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;

        public UserService(HttpClient http, ITokenService tokenService, CustomAuthenticationStateProvider customAuthenticationStateProvider) 
            : base("User", http)
        {
            _httpClient = http;
            _tokenService = tokenService;
            _customAuthenticationStateProvider = customAuthenticationStateProvider;
        }

        public async Task<RegisterResponseDto> RegisterUser(RegisterDto registerDto)
        {
            try
            {
                var registerResponse = await PostAsync<RegisterResponseDto, RegisterDto>("register", registerDto);

                if (registerResponse != null)
                {
                    return registerResponse;
                }
                else
                {
                    return new RegisterResponseDto
                    {
                        Succeeded = false,
                        Errors = new List<string>()
                        {
                            "Error: Null was returned from Post during Registration process"
                        }
                    };
                }
            }
            catch (Exception ex)
            { 
                return new RegisterResponseDto
                {
                    Succeeded = false,
                    Errors = new List<string>()
                    {
                        "Error: " + ex.Message
                    }
                };
            }
        }

        public async Task<LoginResponseDto> LoginUser(LoginDto loginDto)
        {
            try
            {
                var loginResponse = await PostAsync<LoginResponseDto, LoginDto>("login", loginDto);
                TokenDto? token = loginResponse?.Token;

                if (loginResponse != null && token != null) { 
                    await _tokenService.SetToken(token);
                    _customAuthenticationStateProvider.StateChanged();
                    return loginResponse;
                }
                else
                {
                    return new LoginResponseDto
                    {
                        Succeeded = false,
                        Message = "Null Error: Token was not set correctly on login"
                    };
                } 
            }
            catch (Exception ex)
            {
                return new LoginResponseDto
                {
                    Succeeded = false,
                    Message = "Error: " + ex.Message
                };
            }
        }

        public async Task LogoutUser()
        {
            await _tokenService.RemoveToken();
            _customAuthenticationStateProvider.StateChanged();
        }
    }
}
