using System.ComponentModel.DataAnnotations;

namespace churchApp.Models
{
    public class MeetingModel
    {
        public string? name { get; set; }
        public string? location { get; set; }
        public DateOnly date { get; set; }
        public string? startTime { get; set; }
        public string? endTime { get; set; }
    }
}
