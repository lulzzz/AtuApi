using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class abs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_CreatorId",
                table: "PurchaseRequests");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "PurchaseRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 193, 65, 15, 16, 254, 192, 7, 246, 158, 238, 100, 248, 95, 95, 158, 21, 0, 225, 198, 140, 134, 165, 87, 154, 185, 99, 224, 227, 196, 252, 225, 29, 247, 246, 247, 38, 141, 167, 96, 48, 247, 211, 156, 241, 16, 198, 18, 49, 182, 112, 163, 127, 194, 118, 104, 251, 144, 167, 67, 19, 241, 21, 168, 228 }, new byte[] { 208, 248, 0, 189, 19, 87, 163, 76, 13, 23, 28, 246, 181, 26, 3, 162, 253, 80, 147, 203, 195, 110, 249, 32, 251, 93, 93, 97, 171, 188, 35, 206, 212, 111, 28, 242, 211, 202, 196, 66, 72, 14, 134, 249, 98, 86, 164, 214, 6, 16, 143, 103, 159, 50, 109, 166, 4, 71, 250, 2, 104, 175, 201, 129, 196, 172, 229, 197, 24, 240, 101, 8, 116, 163, 114, 32, 5, 152, 236, 134, 43, 147, 135, 48, 236, 134, 73, 62, 200, 124, 34, 1, 73, 54, 254, 121, 255, 158, 162, 68, 183, 186, 208, 77, 131, 227, 58, 68, 2, 57, 240, 133, 22, 145, 192, 208, 240, 231, 92, 214, 57, 103, 179, 157, 208, 213, 24, 111 } });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_CreatorId",
                table: "PurchaseRequests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Users_CreatorId",
                table: "PurchaseRequests");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "PurchaseRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 196, 215, 103, 5, 72, 125, 228, 224, 221, 21, 224, 7, 228, 80, 81, 217, 71, 149, 36, 152, 164, 43, 121, 230, 42, 192, 108, 67, 178, 123, 150, 202, 11, 81, 242, 85, 15, 100, 58, 194, 106, 146, 47, 212, 205, 88, 151, 87, 194, 20, 133, 105, 19, 55, 225, 119, 228, 152, 48, 34, 56, 70, 237, 142 }, new byte[] { 182, 56, 47, 25, 87, 224, 60, 35, 69, 206, 36, 186, 171, 114, 130, 26, 19, 137, 135, 213, 238, 233, 29, 183, 157, 96, 206, 6, 37, 253, 235, 183, 181, 175, 66, 81, 42, 115, 40, 154, 207, 77, 240, 157, 253, 130, 243, 145, 145, 104, 26, 172, 143, 245, 234, 234, 196, 112, 136, 161, 193, 50, 128, 193, 136, 29, 91, 224, 62, 140, 185, 39, 167, 198, 159, 165, 178, 91, 49, 137, 129, 255, 50, 233, 186, 226, 20, 51, 100, 131, 42, 171, 71, 191, 170, 103, 45, 18, 95, 109, 143, 114, 24, 234, 144, 128, 1, 46, 109, 97, 220, 198, 45, 28, 192, 109, 70, 208, 152, 217, 218, 234, 63, 173, 5, 87, 48, 75 } });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Users_CreatorId",
                table: "PurchaseRequests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
