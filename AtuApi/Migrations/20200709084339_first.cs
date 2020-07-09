using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalTemplates",
                columns: table => new
                {
                    TemplateCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalTemplates", x => x.TemplateCode);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    DocNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostingDate = table.Column<DateTime>(nullable: false),
                    CreategDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ProjectCode = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.DocNum);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalDocumentTypes",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false),
                    ApprovalTemplateTemplateCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalDocumentTypes", x => new { x.ApprovalTemplateTemplateCode, x.DocumentTypeId });
                    table.ForeignKey(
                        name: "FK_ApprovalDocumentTypes_ApprovalTemplates_ApprovalTemplateTemplateCode",
                        column: x => x.ApprovalTemplateTemplateCode,
                        principalTable: "ApprovalTemplates",
                        principalColumn: "TemplateCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalDocumentTypes_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestRows",
                columns: table => new
                {
                    PurchaseRequestDocNum = table.Column<int>(nullable: false),
                    LineNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(nullable: true),
                    BusinessPartnerCode = table.Column<string>(nullable: true),
                    RequiredQuantity = table.Column<double>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    TeritoryId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    WareHouse = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestRows", x => new { x.PurchaseRequestDocNum, x.LineNum });
                    table.ForeignKey(
                        name: "FK_PurchaseRequestRows_PurchaseRequests_PurchaseRequestDocNum",
                        column: x => x.PurchaseRequestDocNum,
                        principalTable: "PurchaseRequests",
                        principalColumn: "DocNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalsEmployees",
                columns: table => new
                {
                    ApprovalTemplateTemplateCode = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalsEmployees", x => new { x.ApprovalTemplateTemplateCode, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApprovalsEmployees_ApprovalTemplates_ApprovalTemplateTemplateCode",
                        column: x => x.ApprovalTemplateTemplateCode,
                        principalTable: "ApprovalTemplates",
                        principalColumn: "TemplateCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalsEmployees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersAppovalTemplates",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ApprovalTemplateTemplateCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAppovalTemplates", x => new { x.UserId, x.ApprovalTemplateTemplateCode });
                    table.ForeignKey(
                        name: "FK_UsersAppovalTemplates_ApprovalTemplates_ApprovalTemplateTemplateCode",
                        column: x => x.ApprovalTemplateTemplateCode,
                        principalTable: "ApprovalTemplates",
                        principalColumn: "TemplateCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersAppovalTemplates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName" },
                values: new object[] { -1, "Default" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "PermissionName" },
                values: new object[,]
                {
                    { 19, "CanReadUnitOfMeasures" },
                    { 18, "CanReadTerritories" },
                    { 17, "CanReadRoles" },
                    { 16, "CanModifyRoles" },
                    { 15, "CanCreateRoles" },
                    { 14, "CanReadPurchaseRequests" },
                    { 13, "CanModifyPurchaseRequests" },
                    { 12, "CanCreatePurchaseRequests" },
                    { 11, "CanReadProjects" },
                    { 10, "CanReadItemsWarehouse" },
                    { 9, "CanReadItems" },
                    { 8, "CanReadEmployees" },
                    { 7, "CanReadBusinessPartners" },
                    { 6, "CanModifyApprovalTemplates" },
                    { 5, "CanCreateApprovalTemplates" },
                    { 4, "CanReadApprovalTemplates" },
                    { 3, "CanModifyUsers" },
                    { 2, "CanReadUsers" },
                    { 1, "CanCreateUsers" },
                    { 20, "CanReadUnitOfMeasureGroups" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "PermissionRoles",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 19, 1 },
                    { 18, 1 },
                    { 17, 1 },
                    { 16, 1 },
                    { 15, 1 },
                    { 14, 1 },
                    { 13, 1 },
                    { 12, 1 },
                    { 20, 1 },
                    { 11, 1 },
                    { 9, 1 },
                    { 8, 1 },
                    { 7, 1 },
                    { 6, 1 },
                    { 5, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BranchId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Position", "RoleId", "UserName" },
                values: new object[] { 1, -1, "Example@gamil.com", "Jason", "Buttler", new byte[] { 21, 187, 105, 8, 23, 190, 109, 174, 100, 151, 184, 12, 170, 29, 42, 194, 198, 5, 249, 128, 168, 38, 66, 19, 22, 215, 100, 87, 17, 41, 125, 198, 153, 77, 160, 143, 213, 51, 146, 220, 249, 22, 247, 231, 109, 39, 25, 20, 210, 85, 243, 39, 49, 249, 21, 201, 168, 123, 174, 81, 20, 0, 15, 250 }, new byte[] { 219, 144, 223, 34, 178, 22, 111, 158, 59, 125, 140, 199, 122, 89, 130, 225, 158, 66, 189, 64, 108, 144, 115, 67, 49, 201, 78, 217, 39, 79, 222, 18, 132, 231, 0, 92, 127, 105, 61, 81, 149, 84, 213, 87, 50, 109, 102, 88, 195, 62, 147, 243, 147, 247, 231, 99, 40, 55, 139, 234, 43, 8, 131, 131, 231, 216, 55, 1, 245, 223, 211, 238, 242, 89, 47, 210, 51, 178, 108, 193, 162, 211, 79, 98, 210, 54, 40, 46, 18, 125, 143, 85, 76, 104, 23, 238, 90, 32, 178, 22, 65, 38, 248, 41, 85, 33, 146, 28, 43, 135, 45, 151, 3, 244, 9, 166, 130, 206, 186, 233, 32, 53, 125, 162, 60, 202, 229, 165 }, "Manager", 1, "manager" });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalDocumentTypes_DocumentTypeId",
                table: "ApprovalDocumentTypes",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalsEmployees_UserId",
                table: "ApprovalsEmployees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTemplates_TemplateName",
                table: "ApprovalTemplates",
                column: "TemplateName",
                unique: true,
                filter: "[TemplateName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_RoleId",
                table: "PermissionRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAppovalTemplates_ApprovalTemplateTemplateCode",
                table: "UsersAppovalTemplates",
                column: "ApprovalTemplateTemplateCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalDocumentTypes");

            migrationBuilder.DropTable(
                name: "ApprovalsEmployees");

            migrationBuilder.DropTable(
                name: "PermissionRoles");

            migrationBuilder.DropTable(
                name: "PurchaseRequestRows");

            migrationBuilder.DropTable(
                name: "UsersAppovalTemplates");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "ApprovalTemplates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
