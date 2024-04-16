using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace churchApp.Models.Tables
{
    [Table("Meetings")]
    public class MeetingTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        public string? location { get; set; }
        [Required]
        public DateOnly date { get; set; }
        [Required]
        public string? startTime { get; set; }
        public string? endTime { get; set; }
    }
}
