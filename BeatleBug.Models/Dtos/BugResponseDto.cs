using System.Text.Json.Serialization;

namespace BeatleBug.Models.Dtos
{
    public class BugResponseDto
    {
        public int BugId { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Reporter { get; set; } = String.Empty;
        public string? Assignee { get; set; } = String.Empty;
        [JsonIgnore]
        public int StatusId { get; set; }
        [JsonIgnore]
        public int SeverityId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        [JsonIgnore]
        public Comment? Comments { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public string SeverityDescription { get; set; } = string.Empty;
    }
}
