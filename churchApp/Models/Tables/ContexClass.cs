using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace churchApp.Models.Tables
{
    public class ContexClass:DbContext
    {
        public ContexClass(DbContextOptions<ContexClass> options) : base(options)
        {
        }
        public DbSet<UserTables> Users { get; set; }
        public DbSet<RoleTable> Role { get; set; }
        public DbSet<PrayerTable> Prayer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserTables>()
             .HasOne(u => u.Role)
             .WithMany()
             .HasForeignKey(u => u.roleId);

            modelBuilder.Entity<PrayerTable>()
                .HasOne(p => p.Users)
                .WithMany()
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<RoleTable>().HasData(
          new RoleTable { id = 1, role = "Admin" },
          new RoleTable { id = 2, role = "User" }

      );
        }
    }
}
