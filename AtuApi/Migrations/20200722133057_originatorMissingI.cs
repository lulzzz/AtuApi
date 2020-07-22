using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class originatorMissingI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationsHistory_Users_OrignatorId",
                table: "NotificationsHistory");

            migrationBuilder.DropIndex(
                name: "IX_NotificationsHistory_OrignatorId",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "OrignatorId",
                table: "NotificationsHistory");

            migrationBuilder.AddColumn<int>(
                name: "OriginatorId",
                table: "NotificationsHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 51, 143, 48, 78, 108, 72, 226, 3, 24, 122, 99, 99, 214, 75, 108, 46, 77, 160, 65, 122, 189, 21, 5, 110, 210, 172, 102, 35, 107, 190, 124, 110, 180, 77, 228, 66, 148, 186, 230, 150, 43, 170, 123, 169, 206, 61, 179, 157, 97, 136, 116, 69, 3, 162, 186, 146, 58, 25, 114, 76, 70, 79, 96, 125 }, new byte[] { 79, 242, 214, 87, 128, 40, 136, 194, 82, 82, 181, 7, 229, 179, 200, 196, 67, 212, 62, 105, 86, 128, 21, 166, 118, 40, 209, 166, 32, 129, 207, 147, 231, 253, 141, 12, 145, 252, 83, 101, 45, 161, 229, 53, 35, 106, 104, 179, 147, 245, 67, 110, 213, 141, 77, 209, 158, 0, 111, 81, 24, 185, 195, 184, 120, 172, 203, 45, 209, 46, 47, 74, 163, 38, 247, 179, 111, 29, 68, 8, 9, 226, 86, 101, 207, 234, 242, 150, 116, 151, 212, 132, 1, 125, 243, 38, 3, 79, 0, 216, 132, 103, 116, 110, 211, 233, 149, 190, 232, 56, 35, 105, 0, 145, 193, 198, 132, 133, 209, 204, 114, 89, 112, 218, 39, 254, 230, 221 } });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsHistory_OriginatorId",
                table: "NotificationsHistory",
                column: "OriginatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationsHistory_Users_OriginatorId",
                table: "NotificationsHistory",
                column: "OriginatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationsHistory_Users_OriginatorId",
                table: "NotificationsHistory");

            migrationBuilder.DropIndex(
                name: "IX_NotificationsHistory_OriginatorId",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "OriginatorId",
                table: "NotificationsHistory");

            migrationBuilder.AddColumn<int>(
                name: "OrignatorId",
                table: "NotificationsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 65, 226, 199, 167, 242, 69, 129, 127, 181, 56, 57, 125, 134, 58, 54, 202, 150, 26, 173, 173, 166, 59, 229, 58, 99, 131, 54, 237, 65, 107, 5, 226, 142, 127, 224, 138, 13, 248, 157, 98, 81, 255, 168, 47, 206, 87, 89, 237, 86, 200, 94, 147, 30, 23, 253, 243, 39, 33, 55, 172, 244, 94, 48, 142 }, new byte[] { 8, 217, 221, 69, 209, 124, 156, 149, 156, 101, 163, 34, 149, 84, 75, 180, 139, 198, 146, 28, 209, 225, 187, 4, 43, 31, 15, 250, 169, 7, 210, 239, 19, 104, 232, 199, 18, 232, 196, 16, 207, 0, 52, 94, 99, 243, 79, 25, 162, 235, 40, 31, 165, 249, 149, 74, 115, 109, 112, 49, 21, 233, 85, 121, 146, 196, 187, 9, 189, 186, 64, 89, 195, 89, 87, 35, 182, 87, 138, 73, 104, 27, 37, 238, 252, 254, 249, 232, 45, 216, 64, 22, 191, 215, 9, 234, 138, 245, 168, 9, 201, 28, 88, 10, 81, 43, 165, 108, 90, 186, 123, 214, 11, 133, 52, 11, 198, 151, 213, 184, 253, 52, 162, 91, 130, 145, 101, 244 } });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsHistory_OrignatorId",
                table: "NotificationsHistory",
                column: "OrignatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationsHistory_Users_OrignatorId",
                table: "NotificationsHistory",
                column: "OrignatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
