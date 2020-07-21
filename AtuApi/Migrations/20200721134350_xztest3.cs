using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xztest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RejectedResonsId",
                table: "NotificationsHistory",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 239, 239, 127, 179, 183, 252, 237, 11, 48, 76, 31, 152, 97, 154, 32, 248, 67, 2, 108, 133, 78, 106, 87, 53, 189, 153, 221, 65, 21, 206, 159, 237, 153, 119, 102, 200, 22, 64, 26, 56, 63, 95, 232, 21, 151, 3, 218, 89, 172, 24, 248, 180, 102, 219, 243, 164, 81, 30, 147, 174, 145, 239, 239 }, new byte[] { 230, 144, 155, 197, 213, 70, 68, 29, 167, 254, 88, 218, 124, 86, 164, 27, 163, 213, 72, 182, 227, 78, 223, 159, 196, 114, 190, 48, 9, 44, 241, 105, 29, 36, 70, 140, 150, 132, 241, 101, 72, 127, 34, 196, 219, 54, 246, 79, 68, 78, 245, 179, 59, 115, 180, 89, 195, 224, 213, 69, 85, 167, 254, 52, 161, 65, 103, 33, 89, 70, 124, 148, 118, 159, 176, 210, 49, 223, 59, 201, 26, 7, 10, 114, 191, 27, 217, 160, 135, 230, 59, 128, 4, 199, 31, 4, 126, 70, 231, 168, 85, 59, 143, 207, 98, 222, 127, 187, 113, 76, 224, 139, 156, 157, 139, 144, 211, 7, 177, 9, 73, 131, 54, 176, 231, 109, 93, 93 } });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsHistory_RejectedResonsId",
                table: "NotificationsHistory",
                column: "RejectedResonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationsHistory_RejectResons_RejectedResonsId",
                table: "NotificationsHistory",
                column: "RejectedResonsId",
                principalTable: "RejectResons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationsHistory_RejectResons_RejectedResonsId",
                table: "NotificationsHistory");

            migrationBuilder.DropIndex(
                name: "IX_NotificationsHistory_RejectedResonsId",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "RejectedResonsId",
                table: "NotificationsHistory");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 177, 192, 72, 87, 30, 71, 82, 32, 142, 140, 242, 119, 7, 2, 122, 253, 189, 133, 22, 249, 99, 35, 86, 65, 84, 233, 202, 123, 181, 212, 48, 81, 3, 172, 185, 110, 70, 202, 50, 227, 50, 232, 4, 141, 145, 143, 52, 31, 34, 183, 31, 130, 135, 132, 3, 143, 138, 182, 163, 56, 143, 63, 46, 249 }, new byte[] { 107, 136, 212, 239, 103, 8, 121, 43, 56, 108, 14, 168, 53, 64, 175, 69, 132, 245, 46, 169, 215, 135, 199, 45, 177, 188, 228, 212, 178, 202, 188, 137, 245, 24, 220, 53, 19, 191, 107, 244, 208, 104, 145, 137, 113, 208, 145, 17, 145, 137, 89, 114, 197, 183, 137, 50, 145, 59, 95, 188, 58, 49, 172, 181, 56, 152, 79, 26, 212, 103, 87, 202, 234, 193, 166, 28, 136, 84, 135, 221, 105, 24, 128, 98, 165, 191, 178, 96, 30, 22, 29, 137, 118, 187, 83, 40, 151, 130, 145, 152, 69, 225, 87, 250, 110, 1, 58, 99, 8, 147, 120, 63, 236, 83, 163, 100, 10, 94, 161, 220, 250, 142, 13, 121, 201, 14, 5, 0 } });
        }
    }
}
