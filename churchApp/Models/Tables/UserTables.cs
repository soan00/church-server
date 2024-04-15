using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace churchApp.Models.Tables
{
    [Table("UserTable")]
    public class UserTables{       
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        public string? name { get; set; }      
        [Column("Email")]
        public string? email { get; set; }
        [Column("Password")]
        public string? password { get; set; }
        [Column("PhoneNo")]
        public long phoneNo { get; set; }
        [Column("Role Id")]
        public int? roleId { get; set; }     
        public RoleTable? Role { get; set; }
    }
}
