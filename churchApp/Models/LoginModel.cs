using churchApp.Models.Tables;
using System.ComponentModel.DataAnnotations;

namespace churchApp.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string? emailId { get; set; }
        [Required]
        public string? password { get; set; }
        public UserTables? User { get; set; }
    }
}
