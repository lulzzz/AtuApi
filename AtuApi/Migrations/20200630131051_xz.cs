using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xz : Migration
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
                name: "ApprovalsEmployees",
                columns: table => new
                {
                    ApprovalCode = table.Column<int>(nullable: false),
                    EmployeeCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalsEmployees", x => new { x.ApprovalCode, x.EmployeeCode });
                    table.ForeignKey(
                        name: "FK_ApprovalsEmployees_ApprovalTemplates_ApprovalCode",
                        column: x => x.ApprovalCode,
                        principalTable: "ApprovalTemplates",
                        principalColumn: "TemplateCode",
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
                    ApprovalTemplateCode = table.Column<int>(nullable: false),
                    ApprovalTemplateTemplateCode = table.Column<int>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ApprovalTemplates_ApprovalTemplateTemplateCode",
                        column: x => x.ApprovalTemplateTemplateCode,
                        principalTable: "ApprovalTemplates",
                        principalColumn: "TemplateCode",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName" },
                values: new object[] { -1, "Default" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "PermissionName" },
                values: new object[,]
                {
                    { 1, "CanCreateUsers" },
                    { 2, "CanDeleteUsers" },
                    { 3, "CanReadUsers" },
                    { 4, "CanModifyUsers" }
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
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ApprovalTemplateCode", "ApprovalTemplateTemplateCode", "BranchId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Position", "RoleId", "UserName" },
                values: new object[] { 1, 0, null, -1, "Example@gamil.com", "Jason", "Buttler", new byte[] { 220, 153, 74, 111, 126, 251, 105, 68, 228, 189, 147, 41, 7, 87, 68, 240, 25, 20, 240, 117, 242, 7, 23, 82, 154, 141, 205, 211, 231, 48, 151, 195, 243, 144, 37, 89, 43, 118, 234, 108, 41, 229, 51, 83, 223, 63, 7, 163, 241, 24, 82, 32, 190, 22, 84, 115, 135, 236, 83, 81, 85, 253, 112, 60 }, new byte[] { 29, 226, 176, 236, 127, 239, 225, 184, 8, 192, 151, 180, 82, 149, 216, 61, 219, 49, 114, 210, 237, 98, 3, 47, 165, 129, 14, 86, 198, 9, 215, 211, 157, 91, 172, 19, 227, 244, 108, 161, 224, 6, 236, 127, 199, 76, 200, 166, 26, 43, 110, 166, 40, 189, 96, 90, 28, 149, 110, 58, 158, 67, 157, 143, 138, 143, 109, 59, 108, 34, 41, 178, 238, 212, 149, 81, 231, 52, 247, 157, 243, 141, 196, 59, 80, 252, 237, 246, 219, 98, 224, 146, 167, 174, 193, 92, 79, 132, 253, 37, 111, 156, 52, 128, 88, 157, 0, 14, 215, 42, 158, 70, 139, 159, 195, 243, 116, 8, 59, 219, 19, 108, 30, 38, 49, 156, 159, 25 }, "Manager", 1, "manager" });

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
                name: "IX_Users_ApprovalTemplateTemplateCode",
                table: "Users",
                column: "ApprovalTemplateTemplateCode");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalsEmployees");

            migrationBuilder.DropTable(
                name: "PermissionRoles");

            migrationBuilder.DropTable(
                name: "PurchaseRequestRows");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "ApprovalTemplates");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
