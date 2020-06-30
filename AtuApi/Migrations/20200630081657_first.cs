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
                    ApprovalTemplateCode = table.Column<int>(nullable: false),
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
                columns: new[] { "Id", "ApprovalTemplateCode", "BranchId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Position", "RoleId", "UserName" },
                values: new object[] { 1, 0, -1, "Example@gamil.com", "Jason", "Buttler", new byte[] { 145, 95, 202, 103, 16, 11, 73, 186, 39, 73, 231, 17, 196, 252, 115, 204, 147, 105, 127, 223, 216, 47, 137, 12, 11, 15, 43, 198, 63, 106, 127, 12, 3, 34, 66, 220, 202, 105, 132, 89, 35, 207, 231, 114, 196, 217, 229, 40, 20, 166, 163, 159, 148, 146, 62, 5, 14, 50, 145, 252, 6, 112, 24, 136 }, new byte[] { 233, 49, 79, 225, 39, 251, 228, 142, 168, 151, 225, 117, 181, 209, 220, 126, 131, 143, 133, 89, 200, 5, 104, 14, 144, 40, 88, 97, 206, 127, 233, 93, 7, 89, 128, 30, 116, 103, 81, 28, 240, 95, 130, 71, 33, 208, 146, 10, 149, 65, 156, 218, 42, 165, 153, 178, 118, 253, 193, 30, 55, 42, 21, 35, 32, 226, 38, 234, 157, 38, 19, 155, 215, 207, 47, 134, 86, 76, 19, 156, 168, 128, 69, 41, 118, 199, 59, 44, 52, 145, 65, 158, 126, 195, 29, 197, 88, 187, 202, 160, 164, 32, 241, 8, 179, 90, 154, 6, 29, 36, 142, 201, 235, 161, 75, 65, 164, 210, 148, 170, 18, 237, 172, 43, 197, 164, 151, 88 }, "Manager", 1, "manager" });

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
                name: "ApprovalTemplates");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
