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
    [Migration("20200713132610_7")]
    partial class _7
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
                            PasswordHash = new byte[] { 99, 174, 232, 226, 158, 226, 140, 67, 60, 93, 111, 31, 150, 176, 255, 219, 217, 12, 167, 197, 134, 1, 68, 171, 78, 21, 232, 46, 7, 238, 196, 67, 185, 132, 198, 126, 190, 16, 50, 25, 58, 52, 19, 240, 126, 136, 58, 87, 126, 62, 232, 48, 52, 71, 255, 73, 250, 96, 160, 88, 7, 53, 38, 246 },
                            PasswordSalt = new byte[] { 5, 141, 23, 31, 122, 191, 127, 194, 185, 0, 13, 40, 144, 29, 148, 121, 176, 183, 247, 65, 6, 53, 94, 56, 57, 79, 15, 165, 99, 191, 3, 144, 208, 28, 222, 209, 171, 105, 15, 211, 71, 173, 119, 242, 244, 103, 253, 248, 233, 107, 160, 50, 192, 161, 38, 172, 100, 191, 180, 244, 59, 13, 57, 35, 209, 129, 22, 217, 222, 63, 79, 155, 145, 160, 7, 36, 220, 5, 9, 99, 149, 87, 142, 201, 95, 174, 49, 58, 175, 195, 249, 103, 57, 190, 157, 190, 102, 228, 173, 185, 105, 132, 252, 22, 116, 89, 61, 98, 183, 208, 208, 123, 231, 128, 21, 41, 173, 249, 233, 195, 79, 137, 79, 111, 225, 57, 99, 231 },
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

                    b.Property<int>("UserLevel")
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

            modelBuilder.Entity("DataModels.Models.NotificationsHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<string>("ApproverStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ObjectTypeId")
                        .HasColumnType("int");

                    b.Property<int>("OrignatorId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WatchStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("ObjectTypeId");

                    b.HasIndex("OrignatorId");

                    b.ToTable("NotificationsHistory");
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

                    b.Property<int>("ObjctTypeId")
                        .HasColumnType("int");

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

                    b.HasIndex("ObjctTypeId");

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

                    b.Property<string>("WareHouseCode")
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

            modelBuilder.Entity("DataModels.Models.NotificationsHistory", b =>
                {
                    b.HasOne("AtuApi.Models.User", "Approver")
                        .WithMany("ApproverNotifications")
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataModels.Models.DocumentType", "ObjectType")
                        .WithMany()
                        .HasForeignKey("ObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtuApi.Models.User", "Orignator")
                        .WithMany("OriginatorNotifications")
                        .HasForeignKey("OrignatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModels.Models.PurchaseRequest", b =>
                {
                    b.HasOne("AtuApi.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("DataModels.Models.DocumentType", "ObjctType")
                        .WithMany()
                        .HasForeignKey("ObjctTypeId")
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
