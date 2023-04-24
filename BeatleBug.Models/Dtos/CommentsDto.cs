namespace BeatleBug.Models.Dtos
{
    public class CommentsDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}