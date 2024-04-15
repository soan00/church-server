using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace churchApp.Models.Tables
{
    [Table("Prayer")]
    public class PrayerTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? prayerRequest { get; set; }
        [Required]
        public string? requestFor { get; set; }

        public int userId { get; set; }
        public UserTables? Users { get; set; }
        
    }
}
