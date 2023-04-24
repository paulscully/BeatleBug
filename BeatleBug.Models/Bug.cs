using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BeatleBug.Models
{
    [Table("Bugs")]
    public class Bug
    {
        public int BugId { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Reporter { get; set; } = String.Empty;
        [AllowNull]
        public string? Assignee { get; set; } = String.Empty;
        public int StatusId { get; set; }
        public int SeverityId { get; set; } 
        public DateTime CreateDate { get; set; }
        [AllowNull]
        public DateTime? UpdateDate { get; set; }
        [AllowNull]
        public DateTime? CloseDate { get; set; }
        [AllowNull]
        public Comment? Comments { get; set; }
    }
}
