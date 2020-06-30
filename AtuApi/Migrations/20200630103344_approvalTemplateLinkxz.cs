using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class approvalTemplateLinkxz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ApprovalTemplates_ApprovalTemplateTemplateCode",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApprovalTemplateTemplateCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApprovalTemplateTemplateCode",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 177, 186, 166, 162, 37, 170, 149, 12, 212, 20, 64, 112, 90, 111, 97, 81, 139, 145, 223, 22, 110, 5, 39, 105, 187, 10, 217, 82, 30, 57, 226, 46, 189, 221, 35, 209, 214, 154, 155, 89, 2, 47, 214, 228, 119, 140, 172, 197, 241, 216, 231, 144, 89, 220, 235, 111, 69, 120, 124, 234, 62, 54, 204, 140 }, new byte[] { 28, 191, 38, 236, 86, 31, 73, 48, 141, 180, 22, 185, 11, 181, 94, 173, 128, 28, 232, 26, 31, 213, 68, 128, 157, 231, 0, 187, 121, 241, 16, 77, 121, 162, 67, 167, 203, 168, 122, 51, 35, 41, 68, 239, 177, 215, 11, 212, 58, 149, 77, 25, 37, 179, 239, 211, 163, 30, 252, 86, 227, 125, 216, 129, 187, 126, 234, 25, 213, 25, 123, 39, 35, 87, 175, 203, 181, 93, 91, 95, 110, 72, 12, 224, 19, 17, 16, 139, 176, 61, 94, 146, 35, 156, 190, 195, 241, 110, 200, 253, 90, 142, 161, 229, 46, 25, 169, 49, 28, 102, 237, 96, 149, 204, 102, 251, 128, 168, 134, 160, 151, 189, 170, 218, 177, 138, 214, 148 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApprovalTemplateCode",
                table: "Users",
                column: "ApprovalTemplateCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ApprovalTemplates_ApprovalTemplateCode",
                table: "Users",
                column: "ApprovalTemplateCode",
                principalTable: "ApprovalTemplates",
                principalColumn: "TemplateCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ApprovalTemplates_ApprovalTemplateCode",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApprovalTemplateCode",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalTemplateTemplateCode",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 252, 62, 235, 60, 244, 110, 250, 131, 171, 193, 88, 56, 0, 127, 88, 159, 164, 127, 101, 126, 236, 251, 2, 80, 180, 206, 122, 80, 65, 77, 31, 12, 175, 131, 255, 212, 88, 11, 69, 77, 86, 97, 231, 43, 54, 188, 148, 205, 182, 1, 171, 155, 235, 16, 71, 15, 28, 5, 167, 222, 141, 29, 248, 128 }, new byte[] { 87, 79, 185, 188, 87, 83, 124, 212, 133, 46, 229, 190, 26, 212, 19, 91, 241, 245, 82, 63, 175, 3, 34, 94, 76, 158, 212, 152, 146, 6, 230, 241, 239, 221, 202, 251, 157, 68, 63, 239, 228, 68, 127, 191, 88, 16, 254, 24, 142, 201, 88, 201, 202, 155, 137, 164, 90, 132, 64, 210, 115, 122, 83, 242, 211, 25, 106, 177, 101, 235, 3, 107, 123, 33, 29, 151, 128, 95, 192, 5, 218, 50, 183, 114, 228, 37, 72, 9, 57, 27, 128, 75, 154, 96, 103, 147, 136, 47, 125, 69, 28, 109, 175, 251, 91, 228, 121, 48, 61, 176, 83, 16, 3, 76, 58, 52, 166, 50, 70, 70, 69, 246, 237, 170, 185, 155, 163, 97 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApprovalTemplateTemplateCode",
                table: "Users",
                column: "ApprovalTemplateTemplateCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ApprovalTemplates_ApprovalTemplateTemplateCode",
                table: "Users",
                column: "ApprovalTemplateTemplateCode",
                principalTable: "ApprovalTemplates",
                principalColumn: "TemplateCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
