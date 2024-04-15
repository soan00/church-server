using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace churchApp.Models.Tables
{
    [Table("Role")]
    public class RoleTable
    {
        [Key]
        public int id { get; set; }
        public string? role { get; set; }
    }
}
