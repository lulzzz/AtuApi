using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xzzx22asad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDocumentTypes_DocumentTypes_ApprovalTemplateTemplateCode",
                table: "ApprovalDocumentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_DocumentTypeId",
                table: "ApprovalDocumentTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 39, 172, 167, 17, 217, 243, 74, 76, 125, 183, 18, 6, 144, 47, 56, 181, 15, 99, 53, 162, 227, 4, 122, 90, 105, 131, 156, 68, 210, 50, 225, 183, 109, 23, 207, 241, 195, 238, 183, 249, 80, 24, 165, 189, 141, 164, 67, 27, 59, 71, 124, 69, 211, 71, 214, 8, 252, 77, 47, 75, 57, 241, 159, 80 }, new byte[] { 205, 197, 113, 76, 72, 168, 101, 96, 182, 187, 106, 103, 192, 246, 184, 150, 223, 172, 223, 201, 28, 114, 191, 210, 189, 120, 7, 130, 163, 118, 179, 233, 54, 66, 180, 50, 230, 33, 169, 18, 230, 143, 125, 198, 112, 244, 181, 67, 169, 152, 186, 120, 179, 152, 82, 207, 152, 173, 94, 127, 52, 120, 173, 29, 146, 61, 58, 191, 195, 41, 104, 27, 114, 153, 110, 66, 153, 44, 111, 162, 8, 128, 152, 161, 189, 67, 246, 136, 150, 224, 230, 41, 146, 234, 147, 61, 198, 45, 15, 198, 252, 169, 39, 15, 194, 76, 122, 234, 78, 111, 17, 15, 55, 193, 12, 234, 35, 37, 237, 107, 234, 153, 100, 28, 81, 151, 192, 114 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_ApprovalTemplateTemplateCode",
                table: "ApprovalDocumentTypes",
                column: "ApprovalTemplateTemplateCode",
                principalTable: "ApprovalTemplates",
                principalColumn: "TemplateCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDocumentTypes_DocumentTypes_DocumentTypeId",
                table: "ApprovalDocumentTypes",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_ApprovalTemplateTemplateCode",
                table: "ApprovalDocumentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDocumentTypes_DocumentTypes_DocumentTypeId",
                table: "ApprovalDocumentTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 188, 167, 73, 200, 254, 151, 144, 236, 179, 125, 66, 126, 29, 23, 204, 148, 24, 92, 130, 134, 162, 44, 52, 131, 190, 176, 185, 183, 157, 43, 78, 210, 249, 243, 75, 69, 238, 219, 58, 134, 85, 150, 62, 136, 181, 50, 99, 83, 51, 81, 10, 17, 20, 71, 106, 154, 12, 151, 181, 51, 253, 235 }, new byte[] { 172, 28, 104, 172, 72, 64, 195, 78, 165, 2, 73, 53, 43, 142, 150, 136, 217, 203, 160, 242, 230, 20, 0, 208, 99, 138, 50, 35, 52, 2, 241, 31, 201, 50, 88, 197, 18, 116, 41, 50, 52, 99, 74, 97, 84, 68, 214, 54, 251, 164, 175, 168, 102, 181, 151, 174, 22, 205, 230, 2, 35, 5, 126, 124, 130, 170, 244, 224, 45, 67, 36, 223, 224, 231, 78, 113, 175, 18, 64, 136, 183, 141, 96, 195, 185, 180, 2, 120, 253, 137, 224, 120, 52, 43, 238, 68, 113, 166, 8, 84, 160, 80, 67, 53, 179, 182, 106, 79, 248, 151, 210, 25, 48, 95, 231, 2, 54, 238, 186, 148, 184, 143, 139, 64, 97, 106, 226, 22 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDocumentTypes_DocumentTypes_ApprovalTemplateTemplateCode",
                table: "ApprovalDocumentTypes",
                column: "ApprovalTemplateTemplateCode",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_DocumentTypeId",
                table: "ApprovalDocumentTypes",
                column: "DocumentTypeId",
                principalTable: "ApprovalTemplates",
                principalColumn: "TemplateCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
