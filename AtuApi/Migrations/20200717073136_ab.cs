using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class ab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PurchaseRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WatchStatus",
                table: "NotificationsHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApproverStatus",
                table: "NotificationsHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 196, 215, 103, 5, 72, 125, 228, 224, 221, 21, 224, 7, 228, 80, 81, 217, 71, 149, 36, 152, 164, 43, 121, 230, 42, 192, 108, 67, 178, 123, 150, 202, 11, 81, 242, 85, 15, 100, 58, 194, 106, 146, 47, 212, 205, 88, 151, 87, 194, 20, 133, 105, 19, 55, 225, 119, 228, 152, 48, 34, 56, 70, 237, 142 }, new byte[] { 182, 56, 47, 25, 87, 224, 60, 35, 69, 206, 36, 186, 171, 114, 130, 26, 19, 137, 135, 213, 238, 233, 29, 183, 157, 96, 206, 6, 37, 253, 235, 183, 181, 175, 66, 81, 42, 115, 40, 154, 207, 77, 240, 157, 253, 130, 243, 145, 145, 104, 26, 172, 143, 245, 234, 234, 196, 112, 136, 161, 193, 50, 128, 193, 136, 29, 91, 224, 62, 140, 185, 39, 167, 198, 159, 165, 178, 91, 49, 137, 129, 255, 50, 233, 186, 226, 20, 51, 100, 131, 42, 171, 71, 191, 170, 103, 45, 18, 95, 109, 143, 114, 24, 234, 144, 128, 1, 46, 109, 97, 220, 198, 45, 28, 192, 109, 70, 208, 152, 217, 218, 234, 63, 173, 5, 87, 48, 75 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PurchaseRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "WatchStatus",
                table: "NotificationsHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApproverStatus",
                table: "NotificationsHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 227, 94, 231, 179, 115, 154, 194, 216, 211, 44, 208, 158, 69, 219, 189, 220, 245, 14, 201, 189, 10, 210, 156, 196, 98, 0, 145, 161, 56, 129, 80, 233, 108, 147, 172, 127, 50, 160, 95, 83, 93, 238, 8, 69, 255, 74, 42, 171, 98, 99, 85, 40, 134, 167, 109, 176, 127, 68, 174, 198, 116, 6, 81, 99 }, new byte[] { 187, 7, 111, 18, 31, 96, 246, 130, 91, 43, 126, 7, 135, 61, 112, 237, 22, 123, 226, 184, 110, 241, 174, 161, 197, 214, 14, 81, 221, 52, 91, 77, 49, 121, 39, 15, 235, 163, 117, 18, 214, 250, 185, 110, 207, 234, 181, 29, 158, 154, 141, 235, 224, 35, 171, 202, 87, 78, 46, 201, 212, 141, 150, 37, 101, 6, 195, 159, 236, 203, 224, 232, 210, 141, 90, 245, 39, 161, 42, 77, 27, 113, 94, 143, 162, 33, 151, 121, 79, 81, 36, 232, 124, 150, 94, 165, 197, 209, 71, 126, 35, 233, 74, 1, 116, 141, 60, 36, 236, 185, 43, 117, 69, 169, 23, 52, 250, 40, 176, 78, 24, 113, 240, 120, 105, 5, 3, 183 } });
        }
    }
}
