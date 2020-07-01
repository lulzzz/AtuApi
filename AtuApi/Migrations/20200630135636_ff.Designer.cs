﻿// <auto-generated />
using System;
using DataContextHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtuApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200630135636_ff")]
    partial class ff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtuApi.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            BranchName = "Default"
                        });
                });

            modelBuilder.Entity("AtuApi.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PermissionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionName = "CanCreateUsers"
                        },
                        new
                        {
                            Id = 2,
                            PermissionName = "CanReadUsers"
                        },
                        new
                        {
                            Id = 3,
                            PermissionName = "CanModifyUsers"
                        },
                        new
                        {
                            Id = 4,
                            PermissionName = "CanReadApprovalTemplates"
                        },
                        new
                        {
                            Id = 5,
                            PermissionName = "CanCreateApprovalTemplates"
                        },
                        new
                        {
                            Id = 6,
                            PermissionName = "CanModifyApprovalTemplates"
                        },
                        new
                        {
                            Id = 7,
                            PermissionName = "CanReadBusinessPartners"
                        },
                        new
                        {
                            Id = 8,
                            PermissionName = "CanReadEmployees"
                        },
                        new
                        {
                            Id = 9,
                            PermissionName = "CanReadItems"
                        },
                        new
                        {
                            Id = 10,
                            PermissionName = "CanReadItemsWarehouse"
                        },
                        new
                        {
                            Id = 11,
                            PermissionName = "CanReadProjects"
                        },
                        new
                        {
                            Id = 12,
                            PermissionName = "CanCreatePurchaseRequests"
                        },
                        new
                        {
                            Id = 13,
                            PermissionName = "CanModifyPurchaseRequests"
                        },
                        new
                        {
                            Id = 14,
                            PermissionName = "CanReadPurchaseRequests"
                        },
                        new
                        {
                            Id = 15,
                            PermissionName = "CanCreateRoles"
                        },
                        new
                        {
                            Id = 16,
                            PermissionName = "CanModifyRoles"
                        },
                        new
                        {
                            Id = 17,
                            PermissionName = "CanReadRoles"
                        },
                        new
                        {
                            Id = 18,
                            PermissionName = "CanReadTerritories"
                        },
                        new
                        {
                            Id = 19,
                            PermissionName = "CanReadUnitOfMeasures"
                        },
                        new
                        {
                            Id = 20,
                            PermissionName = "CanReadUnitOfMeasureGroups"
                        });
                });

            modelBuilder.Entity("AtuApi.Models.PermissionRoles", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("PermissionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("PermissionRoles");
                });

            modelBuilder.Entity("AtuApi.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("AtuApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApprovalTemplateCode")
                        .HasColumnType("int");

                    b.Property<int?>("ApprovalTemplateTemplateCode")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalTemplateTemplateCode");

                    b.HasIndex("BranchId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalTemplateCode = 0,
                            BranchId = -1,
                            Email = "Example@gamil.com",
                            FirstName = "Jason",
                            IsActive = false,
                            LastName = "Buttler",
                            PasswordHash = new byte[] { 179, 162, 91, 102, 119, 11, 187, 60, 18, 169, 214, 253, 53, 52, 245, 123, 86, 30, 242, 152, 186, 171, 6, 149, 248, 21, 193, 80, 238, 1, 164, 52, 120, 181, 235, 123, 36, 163, 81, 231, 150, 55, 30, 236, 177, 226, 242, 53, 12, 195, 14, 83, 242, 195, 211, 136, 16, 7, 125, 207, 241, 221, 25, 65 },
                            PasswordSalt = new byte[] { 48, 133, 112, 4, 74, 6, 177, 89, 241, 108, 75, 161, 140, 113, 54, 248, 245, 248, 94, 28, 104, 15, 148, 73, 9, 96, 52, 23, 77, 53, 147, 135, 161, 137, 180, 249, 238, 21, 174, 135, 44, 172, 218, 1, 84, 95, 236, 25, 117, 55, 174, 46, 20, 137, 139, 176, 161, 20, 100, 69, 117, 55, 45, 78, 53, 175, 17, 126, 40, 110, 78, 34, 32, 148, 211, 94, 195, 92, 89, 75, 230, 44, 8, 214, 5, 69, 217, 27, 131, 21, 129, 23, 101, 135, 27, 96, 50, 216, 222, 5, 19, 81, 27, 2, 245, 115, 193, 214, 105, 20, 84, 113, 66, 38, 226, 93, 124, 122, 136, 70, 38, 0, 199, 33, 69, 178, 112, 216 },
                            Position = "Manager",
                            RoleId = 1,
                            UserName = "manager"
                        });
                });

            modelBuilder.Entity("DataModels.Models.ApprovalTemplate", b =>
                {
                    b.Property<int>("TemplateCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TemplateName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TemplateCode");

                    b.HasIndex("TemplateName")
                        .IsUnique()
                        .HasFilter("[TemplateName] IS NOT NULL");

                    b.ToTable("ApprovalTemplates");
                });

            modelBuilder.Entity("DataModels.Models.ApprovalsEmployees", b =>
                {
                    b.Property<int>("ApprovalCode")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeCode")
                        .HasColumnType("int");

                    b.HasKey("ApprovalCode", "EmployeeCode");

                    b.ToTable("ApprovalsEmployees");
                });

            modelBuilder.Entity("DataModels.Models.PurchaseRequest", b =>
                {
                    b.Property<int>("DocNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreategDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocNum");

                    b.ToTable("PurchaseRequests");
                });

            modelBuilder.Entity("DataModels.Models.PurchaseRequestRow", b =>
                {
                    b.Property<int>("PurchaseRequestDocNum")
                        .HasColumnType("int");

                    b.Property<int>("LineNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessPartnerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RequiredQuantity")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeritoryId")
                        .HasColumnType("int");

                    b.Property<string>("WareHouse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PurchaseRequestDocNum", "LineNum");

                    b.ToTable("PurchaseRequestRows");
                });

            modelBuilder.Entity("AtuApi.Models.PermissionRoles", b =>
                {
                    b.HasOne("AtuApi.Models.Permission", "Permissions")
                        .WithMany("PermissionRoles")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtuApi.Models.Role", "Roles")
                        .WithMany("PermissionRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AtuApi.Models.User", b =>
                {
                    b.HasOne("DataModels.Models.ApprovalTemplate", "ApprovalTemplate")
                        .WithMany("Users")
                        .HasForeignKey("ApprovalTemplateTemplateCode");

                    b.HasOne("AtuApi.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtuApi.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModels.Models.ApprovalsEmployees", b =>
                {
                    b.HasOne("DataModels.Models.ApprovalTemplate", "ApprovalTemplate")
                        .WithMany("ApprovalsEmployees")
                        .HasForeignKey("ApprovalCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModels.Models.PurchaseRequestRow", b =>
                {
                    b.HasOne("DataModels.Models.PurchaseRequest", null)
                        .WithMany("Rows")
                        .HasForeignKey("PurchaseRequestDocNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}