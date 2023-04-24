namespace BeatleBug.Models.Dtos
{
    public class LoginResponseDto
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; } = string.Empty;

        public TokenDto? Token { get; set; }
    }
}
