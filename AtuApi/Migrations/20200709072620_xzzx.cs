using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xzzx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_ApprovalTemplates_ApprovalTemplateTemplateCode",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_ApprovalTemplateTemplateCode",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "ApprovalTemplateTemplateCode",
                table: "DocumentTypes");

            migrationBuilder.CreateTable(
                name: "ApprovalDocumentTypes",
                columns: table => new
                {
                    DocumentTypeID = table.Column<int>(nullable: false),
                    ApprovalTemplateTemplateCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalDocumentTypes", x => new { x.ApprovalTemplateTemplateCode, x.DocumentTypeID });
                    table.ForeignKey(
                        name: "FK_ApprovalDocumentTypes_DocumentTypes_ApprovalTemplateTemplateCode",
                        column: x => x.ApprovalTemplateTemplateCode,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalDocumentTypes_ApprovalTemplates_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "ApprovalTemplates",
                        principalColumn: "TemplateCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 92, 25, 56, 48, 151, 199, 66, 139, 1, 21, 127, 185, 102, 6, 24, 149, 0, 145, 255, 198, 80, 132, 46, 35, 56, 224, 128, 21, 226, 107, 92, 160, 138, 39, 213, 46, 46, 66, 68, 215, 253, 168, 42, 232, 109, 177, 79, 204, 93, 255, 133, 199, 147, 57, 99, 41, 7, 232, 69, 181, 91, 239, 206, 148 }, new byte[] { 255, 105, 8, 233, 211, 130, 136, 165, 239, 207, 178, 70, 190, 142, 116, 180, 84, 236, 76, 237, 83, 167, 183, 95, 169, 13, 163, 70, 63, 156, 42, 58, 231, 253, 194, 183, 23, 231, 86, 234, 127, 30, 175, 33, 224, 232, 183, 244, 163, 85, 65, 25, 191, 177, 6, 119, 10, 187, 97, 41, 110, 85, 250, 77, 83, 207, 243, 26, 24, 162, 241, 3, 15, 24, 65, 224, 132, 42, 76, 146, 168, 40, 143, 24, 230, 69, 17, 92, 101, 46, 191, 225, 18, 13, 0, 44, 14, 53, 119, 93, 221, 165, 225, 37, 158, 162, 54, 210, 126, 226, 88, 14, 48, 232, 121, 64, 219, 125, 26, 151, 109, 112, 234, 43, 166, 248, 172, 57 } });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalDocumentTypes_DocumentTypeID",
                table: "ApprovalDocumentTypes",
                column: "DocumentTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalDocumentTypes");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalTemplateTemplateCode",
                table: "DocumentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 180, 87, 21, 4, 36, 133, 113, 251, 194, 239, 78, 171, 143, 131, 67, 219, 234, 103, 195, 156, 239, 196, 60, 169, 76, 230, 170, 29, 113, 0, 240, 193, 125, 25, 29, 242, 20, 168, 241, 147, 254, 131, 248, 123, 180, 191, 103, 2, 59, 201, 92, 165, 123, 144, 220, 215, 230, 115, 254, 138, 99, 89, 200, 127 }, new byte[] { 159, 250, 60, 236, 120, 100, 171, 186, 91, 30, 141, 166, 234, 223, 93, 90, 1, 157, 237, 137, 69, 134, 217, 93, 103, 133, 41, 151, 52, 118, 233, 28, 251, 221, 177, 100, 142, 58, 141, 139, 210, 221, 214, 145, 86, 117, 177, 207, 27, 11, 236, 86, 96, 78, 172, 157, 25, 76, 111, 189, 119, 159, 194, 82, 142, 240, 219, 169, 24, 95, 205, 237, 140, 252, 11, 95, 17, 12, 143, 200, 170, 112, 234, 8, 39, 104, 234, 221, 218, 44, 239, 101, 24, 100, 90, 140, 204, 142, 79, 206, 3, 236, 85, 140, 5, 230, 21, 140, 36, 76, 133, 125, 225, 60, 135, 137, 136, 30, 60, 5, 166, 185, 11, 118, 195, 180, 84, 132 } });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_ApprovalTemplateTemplateCode",
                table: "DocumentTypes",
                column: "ApprovalTemplateTemplateCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_ApprovalTemplates_ApprovalTemplateTemplateCode",
                table: "DocumentTypes",
                column: "ApprovalTemplateTemplateCode",
                principalTable: "ApprovalTemplates",
                principalColumn: "TemplateCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
