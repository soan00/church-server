using churchApp.Models.Tables;
using System.ComponentModel.DataAnnotations;

namespace churchApp.Models
{
    public class PrayerModel
    {
        public int id { get; set; }
        [Required]
        public string? prayerRequest { get; set; }
        [Required]
        public string? requestFor { get; set; }
        public string? emailId { get; set; }
        public int userId { get; set; }
        public UserTables? Users { get; set; } = null;
    }
}
