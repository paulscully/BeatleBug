using System.ComponentModel.DataAnnotations.Schema;

namespace BeatleBug.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
