using AtuApi.Controllers;
using AtuApi.Models;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataContextHelper
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PermissionRoles> PermissionRoles { get; set; }
        public DbSet<ApprovalTemplate> ApprovalTemplates { get; set; }
        public DbSet<ApprovalsEmployees> ApprovalsEmployees { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestRow> PurchaseRequestRows { get; set; }

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


            modelBuilder.Entity<ApprovalTemplate>()
                .HasKey(x => x.TemplateCode);

            modelBuilder.Entity<ApprovalTemplate>()
              .HasIndex(y => y.TemplateName)
                .IsUnique(true);



            modelBuilder.Entity<ApprovalsEmployees>()
             .HasKey(x => new { x.ApprovalCode, x.EmployeeCode });




            modelBuilder.Entity<ApprovalsEmployees>()
           .HasOne(x => x.ApprovalTemplate)
           .WithMany(e => e.ApprovalsEmployees)
           .HasForeignKey(fx => fx.ApprovalCode);

            modelBuilder.Entity<PurchaseRequest>()
            .HasKey(x => x.DocNum);


            modelBuilder.Entity<PurchaseRequest>()
                .Property(b => b.CreategDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PurchaseRequestRow>()
       .HasKey(x => new { x.PurchaseRequestDocNum, x.LineNum });

            modelBuilder.Entity<PurchaseRequestRow>().Property(x => x.LineNum).ValueGeneratedOnAdd();
            #region InitialData

            modelBuilder.Entity<Permission>().HasData(
          new Permission { PermissionName = "CanCreateUsers", Id = 1 },
          new Permission { PermissionName = "CanDeleteUsers", Id = 2 },
          new Permission { PermissionName = "CanReadUsers", Id = 3 },
          new Permission { PermissionName = "CanModifyUsers", Id = 4 },
          new Permission { PermissionName = "CanModifyUsers", Id = 5 }
          );
            modelBuilder.Entity<Role>().HasData(
         new Role { RoleName = "Admin", Id = 1 });

            modelBuilder.Entity<PermissionRoles>().HasData(
               new PermissionRoles { PermissionId = 1, RoleId = 1 },
               new PermissionRoles { PermissionId = 2, RoleId = 1 },
               new PermissionRoles { PermissionId = 3, RoleId = 1 },
               new PermissionRoles { PermissionId = 4, RoleId = 1 },
               new PermissionRoles { PermissionId = 5, RoleId = 1 }
               );


            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = -1, BranchName = "Default" });
            byte[] passwordHash, passwordSalt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Welcome1"));
            }

            modelBuilder.Entity<User>().HasData(
              new User { Id = 1, BranchId = -1, FirstName = "Admin", LastName = "Admin", UserName = "Admin", RoleId = 1, Position = "Administraton", Email = "Example@gamil.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt });



            #endregion





        }

    }
}
