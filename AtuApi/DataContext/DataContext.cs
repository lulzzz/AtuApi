using AtuApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AtuApi.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            bool creted = Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRoles> PermisionRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionRoles>()
                .HasKey(x => new { x.PermissionId, x.RoleId });

            modelBuilder.Entity<PermissionRoles>()
            .HasOne(p => p.Permissions)
            .WithMany(pe => pe.PermissionRoles)
            .HasForeignKey(m => m.PermissionId);

            modelBuilder.Entity<PermissionRoles>()
                .HasOne(p => p.Roles)
                .WithMany(pe => pe.PermissionRoles)
                .HasForeignKey(m => m.RoleId);
        }

    }
}
