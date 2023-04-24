using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeatleBug.Models.Dtos
{
    public class BugDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Reporter { get; set; } = String.Empty;
        public string? Assignee { get; set; } = String.Empty;
        public int StatusId { get; set; }
        public int SeverityId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; } = null;
        public DateTime? CloseDate { get; set; } = null;
        public CommentsDto? Comments { get; set; } = null;
    }
}
