using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "NotificationsHistory");

            migrationBuilder.AddColumn<string>(
                name: "ApproverStatus",
                table: "NotificationsHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "NotificationsHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WatchStatus",
                table: "NotificationsHistory",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 92, 105, 220, 157, 197, 179, 179, 158, 71, 17, 73, 4, 250, 153, 253, 86, 244, 112, 67, 96, 185, 185, 214, 189, 110, 39, 115, 10, 234, 108, 232, 152, 61, 172, 58, 102, 246, 66, 252, 248, 162, 238, 34, 179, 80, 134, 50, 42, 134, 26, 107, 196, 170, 74, 49, 91, 110, 80, 220, 94, 90, 143, 193 }, new byte[] { 61, 15, 24, 31, 93, 98, 94, 181, 216, 227, 164, 27, 194, 130, 140, 212, 64, 98, 66, 194, 185, 125, 214, 51, 35, 35, 92, 23, 38, 252, 15, 12, 56, 26, 40, 224, 162, 235, 117, 96, 175, 226, 217, 192, 209, 172, 190, 195, 104, 30, 101, 115, 194, 2, 142, 59, 186, 116, 182, 208, 130, 245, 36, 39, 59, 168, 201, 210, 3, 150, 38, 44, 88, 157, 55, 219, 90, 65, 44, 116, 63, 93, 242, 139, 120, 188, 193, 20, 254, 7, 240, 24, 188, 113, 135, 172, 102, 19, 100, 216, 138, 125, 135, 151, 212, 164, 179, 16, 196, 34, 176, 114, 237, 178, 115, 84, 177, 225, 53, 34, 102, 186, 106, 92, 230, 168, 126, 167 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproverStatus",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "WatchStatus",
                table: "NotificationsHistory");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "NotificationsHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 226, 39, 143, 94, 121, 238, 55, 161, 88, 89, 22, 102, 99, 31, 200, 198, 144, 126, 183, 74, 226, 35, 242, 248, 122, 77, 88, 82, 98, 146, 29, 242, 121, 125, 50, 93, 145, 245, 156, 32, 29, 14, 39, 12, 234, 127, 214, 86, 106, 156, 249, 65, 201, 48, 152, 4, 143, 43, 158, 55, 228, 83, 165 }, new byte[] { 96, 205, 246, 49, 60, 203, 187, 92, 87, 252, 43, 255, 85, 204, 27, 7, 254, 241, 109, 172, 153, 39, 127, 111, 140, 123, 220, 149, 47, 152, 236, 241, 221, 250, 45, 88, 48, 174, 173, 214, 40, 216, 117, 150, 30, 157, 16, 237, 200, 127, 181, 224, 84, 218, 85, 170, 53, 112, 37, 138, 19, 26, 236, 190, 45, 98, 39, 100, 39, 117, 220, 124, 205, 140, 51, 147, 131, 50, 220, 237, 78, 90, 32, 6, 145, 56, 35, 198, 16, 175, 206, 62, 41, 56, 211, 99, 218, 32, 114, 68, 100, 142, 155, 26, 113, 213, 23, 26, 117, 116, 84, 6, 19, 185, 42, 184, 162, 227, 210, 16, 188, 40, 220, 73, 124, 77, 225, 107 } });
        }
    }
}
