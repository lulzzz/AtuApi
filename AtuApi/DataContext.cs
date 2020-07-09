using AtuApi;
using AtuApi.Controllers;
using AtuApi.Models;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DataContextHelper
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
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
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<UsersAppovalTemplate> UsersAppovalTemplates { get; set; }
        public DbSet<ApprovalsDocumentType> ApprovalDocumentTypes { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApprovalsDocumentType>()
               .HasKey(x => new { x.ApprovalTemplateTemplateCode, x.DocumentTypeId });

            modelBuilder.Entity<ApprovalsDocumentType>()
            .HasOne(p => p.DocumentType)
            .WithMany(pe => pe.ApprovalDocumentTypes)
            .HasForeignKey(m => m.DocumentTypeId);

            modelBuilder.Entity<ApprovalsDocumentType>()
                .HasOne(p => p.ApprovalTemplate)
                .WithMany(pe => pe.ApprovalsDocumentTypes)
                .HasForeignKey(m => m.ApprovalTemplateTemplateCode);

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

            modelBuilder.Entity<UsersAppovalTemplate>()
                .HasKey(x => new { x.UserId, x.ApprovalTemplateTemplateCode });

            modelBuilder.Entity<UsersAppovalTemplate>()
            .HasOne(p => p.ApprovalTemplate)
            .WithMany(pe => pe.UsersAppovalTemplates)
            .HasForeignKey(m => m.ApprovalTemplateTemplateCode);

            modelBuilder.Entity<UsersAppovalTemplate>()
                .HasOne(p => p.User)
                .WithMany(pe => pe.UsersAppovalTemplates)
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<ApprovalTemplate>()
                .HasKey(x => x.TemplateCode);

            modelBuilder.Entity<ApprovalTemplate>()
              .HasIndex(y => y.TemplateName)
                .IsUnique(true);



            modelBuilder.Entity<ApprovalsEmployees>()
             .HasKey(x => new { x.ApprovalTemplateTemplateCode, x.UserId });

            modelBuilder.Entity<User>().Property(i => i.IsActive).HasDefaultValue(true);



            modelBuilder.Entity<ApprovalsEmployees>()
           .HasOne(x => x.ApprovalTemplate)
           .WithMany(e => e.ApprovalsEmployees)
           .HasForeignKey(fx => fx.ApprovalTemplateTemplateCode);

            modelBuilder.Entity<PurchaseRequest>()
            .HasKey(x => x.DocNum);

            modelBuilder.Entity<PurchaseRequest>();        
 

            modelBuilder.Entity<PurchaseRequest>()
                .Property(b => b.CreategDate)
                .HasDefaultValueSql("getdate()");



            modelBuilder.Entity<PurchaseRequestRow>()
       .HasKey(x => new { x.PurchaseRequestDocNum, x.LineNum });

            modelBuilder.Entity<PurchaseRequestRow>().Property(x => x.LineNum).ValueGeneratedOnAdd();

            #region InitialData

            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();
            var premissions = appSettings.Permissions;
            List<Permission> permissionslist = new List<Permission>();
            for (int i = 1; i < premissions.Count; i++)
            {
                permissionslist.Add(new Permission { PermissionName = premissions[i - 1], Id = i });
            }
            modelBuilder.Entity<Permission>().HasData(permissionslist);


            List<PermissionRoles> permissionRolesList = new List<PermissionRoles>();
            foreach (var permission in permissionslist)
            {
                permissionRolesList.Add(new PermissionRoles { PermissionId = permission.Id, RoleId = 1 });
            };
            modelBuilder.Entity<PermissionRoles>().HasData(permissionRolesList);

            modelBuilder.Entity<Role>().HasData(
            new Role { RoleName = appSettings.SuperUserRole, Id = 1 });

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = -1, BranchName = "Default" });

            byte[] passwordHash, passwordSalt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(appSettings.AdminPassword));
            }

            modelBuilder.Entity<User>().HasData(
              new User { Id = 1, BranchId = -1, FirstName = "Jason", LastName = "Buttler", UserName = "manager", RoleId = 1, Position = "Manager", Email = "Example@gamil.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt });



            #endregion





        }

    }
}
