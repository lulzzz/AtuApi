﻿// <auto-generated />
using System;
using DataContextHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtuApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 7,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 8,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 9,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 10,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 11,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 12,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 13,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 14,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 15,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 16,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 17,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 18,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 19,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 20,
                            RoleId = 1
                        });
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

                    b.Property<int>("SapEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BranchId = -1,
                            Email = "Example@gamil.com",
                            FirstName = "Jason",
                            IsActive = false,
                            LastName = "Buttler",
                            PasswordHash = new byte[] { 2, 222, 135, 73, 4, 131, 25, 181, 28, 208, 54, 69, 217, 38, 101, 29, 111, 148, 131, 36, 213, 170, 4, 200, 169, 229, 156, 154, 69, 3, 174, 56, 5, 20, 143, 67, 181, 138, 91, 234, 247, 232, 178, 137, 188, 68, 18, 224, 132, 244, 215, 81, 173, 219, 237, 1, 2, 161, 86, 49, 130, 100, 41, 116 },
                            PasswordSalt = new byte[] { 149, 234, 75, 43, 254, 255, 69, 89, 7, 82, 26, 15, 136, 213, 113, 171, 47, 7, 227, 2, 252, 165, 133, 89, 146, 91, 146, 95, 59, 88, 166, 3, 72, 195, 67, 156, 50, 229, 199, 145, 72, 26, 246, 13, 38, 240, 66, 159, 237, 95, 93, 6, 123, 49, 174, 115, 55, 244, 198, 30, 35, 128, 35, 106, 130, 254, 29, 46, 36, 238, 136, 104, 11, 157, 58, 189, 219, 94, 13, 11, 29, 56, 97, 117, 201, 227, 236, 88, 39, 6, 61, 119, 117, 14, 82, 140, 181, 108, 175, 142, 91, 148, 11, 95, 152, 157, 31, 92, 123, 180, 86, 243, 128, 18, 15, 226, 91, 162, 184, 94, 71, 42, 97, 26, 142, 144, 88, 102 },
                            Position = "Manager",
                            RoleId = 1,
                            SapEmployeeId = 0,
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

            modelBuilder.Entity("DataModels.Models.ApprovalsDocumentType", b =>
                {
                    b.Property<int>("ApprovalTemplateTemplateCode")
                        .HasColumnType("int");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.HasKey("ApprovalTemplateTemplateCode", "DocumentTypeId");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("ApprovalDocumentTypes");
                });

            modelBuilder.Entity("DataModels.Models.ApprovalsEmployees", b =>
                {
                    b.Property<int>("ApprovalTemplateTemplateCode")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ApprovalTemplateTemplateCode", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ApprovalsEmployees");
                });

            modelBuilder.Entity("DataModels.Models.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
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

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ObjctType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocNum");

                    b.HasIndex("CreatorId");

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

            modelBuilder.Entity("DataModels.Models.UsersAppovalTemplate", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ApprovalTemplateTemplateCode")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ApprovalTemplateTemplateCode");

                    b.HasIndex("ApprovalTemplateTemplateCode");

                    b.ToTable("UsersAppovalTemplates");
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

            modelBuilder.Entity("DataModels.Models.ApprovalsDocumentType", b =>
                {
                    b.HasOne("DataModels.Models.ApprovalTemplate", "ApprovalTemplate")
                        .WithMany("ApprovalsDocumentTypes")
                        .HasForeignKey("ApprovalTemplateTemplateCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModels.Models.DocumentType", "DocumentType")
                        .WithMany("ApprovalDocumentTypes")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModels.Models.ApprovalsEmployees", b =>
                {
                    b.HasOne("DataModels.Models.ApprovalTemplate", "ApprovalTemplate")
                        .WithMany("ApprovalsEmployees")
                        .HasForeignKey("ApprovalTemplateTemplateCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtuApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModels.Models.PurchaseRequest", b =>
                {
                    b.HasOne("AtuApi.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("DataModels.Models.PurchaseRequestRow", b =>
                {
                    b.HasOne("DataModels.Models.PurchaseRequest", null)
                        .WithMany("Rows")
                        .HasForeignKey("PurchaseRequestDocNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModels.Models.UsersAppovalTemplate", b =>
                {
                    b.HasOne("DataModels.Models.ApprovalTemplate", "ApprovalTemplate")
                        .WithMany("UsersAppovalTemplates")
                        .HasForeignKey("ApprovalTemplateTemplateCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtuApi.Models.User", "User")
                        .WithMany("UsersAppovalTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
