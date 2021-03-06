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
    [Migration("20200721134350_xztest3")]
    partial class xztest3
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

                    b.Property<string>("PermissionDescription")
                        .HasColumnType("nvarchar(max)");

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
                            PasswordHash = new byte[] { 134, 239, 239, 127, 179, 183, 252, 237, 11, 48, 76, 31, 152, 97, 154, 32, 248, 67, 2, 108, 133, 78, 106, 87, 53, 189, 153, 221, 65, 21, 206, 159, 237, 153, 119, 102, 200, 22, 64, 26, 56, 63, 95, 232, 21, 151, 3, 218, 89, 172, 24, 248, 180, 102, 219, 243, 164, 81, 30, 147, 174, 145, 239, 239 },
                            PasswordSalt = new byte[] { 230, 144, 155, 197, 213, 70, 68, 29, 167, 254, 88, 218, 124, 86, 164, 27, 163, 213, 72, 182, 227, 78, 223, 159, 196, 114, 190, 48, 9, 44, 241, 105, 29, 36, 70, 140, 150, 132, 241, 101, 72, 127, 34, 196, 219, 54, 246, 79, 68, 78, 245, 179, 59, 115, 180, 89, 195, 224, 213, 69, 85, 167, 254, 52, 161, 65, 103, 33, 89, 70, 124, 148, 118, 159, 176, 210, 49, 223, 59, 201, 26, 7, 10, 114, 191, 27, 217, 160, 135, 230, 59, 128, 4, 199, 31, 4, 126, 70, 231, 168, 85, 59, 143, 207, 98, 222, 127, 187, 113, 76, 224, 139, 156, 157, 139, 144, 211, 7, 177, 9, 73, 131, 54, 176, 231, 109, 93, 93 },
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

                    b.Property<int>("ApproverStatus")
                        .HasColumnType("int");

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

                    b.Property<int?>("RejectedResonsId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WatchStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("ObjectTypeId");

                    b.HasIndex("OrignatorId");

                    b.HasIndex("RejectedResonsId");

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

                    b.Property<int>("CreatorId")
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

                    b.Property<int>("Status")
                        .HasColumnType("int");

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

                    b.Property<int>("TeritoryId")
                        .HasColumnType("int");

                    b.Property<string>("WareHouseCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PurchaseRequestDocNum", "LineNum");

                    b.ToTable("PurchaseRequestRows");
                });

            modelBuilder.Entity("DataModels.Models.RejectResons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RejectorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RejectorId");

                    b.ToTable("RejectResons");
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

                    b.HasOne("DataModels.Models.RejectResons", "RejectedResons")
                        .WithMany()
                        .HasForeignKey("RejectedResonsId");
                });

            modelBuilder.Entity("DataModels.Models.PurchaseRequest", b =>
                {
                    b.HasOne("AtuApi.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("DataModels.Models.RejectResons", b =>
                {
                    b.HasOne("AtuApi.Models.User", "Rejector")
                        .WithMany("RejectResons")
                        .HasForeignKey("RejectorId")
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
