namespace BeatleBug.Models.Dtos
{
    public class RegisterResponseDto
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    }
}
