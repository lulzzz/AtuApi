using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xzzx22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_DocumentTypeID",
                table: "ApprovalDocumentTypes");

            migrationBuilder.RenameColumn(
                name: "DocumentTypeID",
                table: "ApprovalDocumentTypes",
                newName: "DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalDocumentTypes_DocumentTypeID",
                table: "ApprovalDocumentTypes",
                newName: "IX_ApprovalDocumentTypes_DocumentTypeId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 188, 167, 73, 200, 254, 151, 144, 236, 179, 125, 66, 126, 29, 23, 204, 148, 24, 92, 130, 134, 162, 44, 52, 131, 190, 176, 185, 183, 157, 43, 78, 210, 249, 243, 75, 69, 238, 219, 58, 134, 85, 150, 62, 136, 181, 50, 99, 83, 51, 81, 10, 17, 20, 71, 106, 154, 12, 151, 181, 51, 253, 235 }, new byte[] { 172, 28, 104, 172, 72, 64, 195, 78, 165, 2, 73, 53, 43, 142, 150, 136, 217, 203, 160, 242, 230, 20, 0, 208, 99, 138, 50, 35, 52, 2, 241, 31, 201, 50, 88, 197, 18, 116, 41, 50, 52, 99, 74, 97, 84, 68, 214, 54, 251, 164, 175, 168, 102, 181, 151, 174, 22, 205, 230, 2, 35, 5, 126, 124, 130, 170, 244, 224, 45, 67, 36, 223, 224, 231, 78, 113, 175, 18, 64, 136, 183, 141, 96, 195, 185, 180, 2, 120, 253, 137, 224, 120, 52, 43, 238, 68, 113, 166, 8, 84, 160, 80, 67, 53, 179, 182, 106, 79, 248, 151, 210, 25, 48, 95, 231, 2, 54, 238, 186, 148, 184, 143, 139, 64, 97, 106, 226, 22 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_DocumentTypeId",
                table: "ApprovalDocumentTypes",
                column: "DocumentTypeId",
                principalTable: "ApprovalTemplates",
                principalColumn: "TemplateCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_DocumentTypeId",
                table: "ApprovalDocumentTypes");

            migrationBuilder.RenameColumn(
                name: "DocumentTypeId",
                table: "ApprovalDocumentTypes",
                newName: "DocumentTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalDocumentTypes_DocumentTypeId",
                table: "ApprovalDocumentTypes",
                newName: "IX_ApprovalDocumentTypes_DocumentTypeID");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 92, 25, 56, 48, 151, 199, 66, 139, 1, 21, 127, 185, 102, 6, 24, 149, 0, 145, 255, 198, 80, 132, 46, 35, 56, 224, 128, 21, 226, 107, 92, 160, 138, 39, 213, 46, 46, 66, 68, 215, 253, 168, 42, 232, 109, 177, 79, 204, 93, 255, 133, 199, 147, 57, 99, 41, 7, 232, 69, 181, 91, 239, 206, 148 }, new byte[] { 255, 105, 8, 233, 211, 130, 136, 165, 239, 207, 178, 70, 190, 142, 116, 180, 84, 236, 76, 237, 83, 167, 183, 95, 169, 13, 163, 70, 63, 156, 42, 58, 231, 253, 194, 183, 23, 231, 86, 234, 127, 30, 175, 33, 224, 232, 183, 244, 163, 85, 65, 25, 191, 177, 6, 119, 10, 187, 97, 41, 110, 85, 250, 77, 83, 207, 243, 26, 24, 162, 241, 3, 15, 24, 65, 224, 132, 42, 76, 146, 168, 40, 143, 24, 230, 69, 17, 92, 101, 46, 191, 225, 18, 13, 0, 44, 14, 53, 119, 93, 221, 165, 225, 37, 158, 162, 54, 210, 126, 226, 88, 14, 48, 232, 121, 64, 219, 125, 26, 151, 109, 112, 234, 43, 166, 248, 172, 57 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDocumentTypes_ApprovalTemplates_DocumentTypeID",
                table: "ApprovalDocumentTypes",
                column: "DocumentTypeID",
                principalTable: "ApprovalTemplates",
                principalColumn: "TemplateCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
