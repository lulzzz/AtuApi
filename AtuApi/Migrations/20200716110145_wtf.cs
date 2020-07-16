using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class wtf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PurchaseRequestRows");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PurchaseRequestRows");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PurchaseRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PurchaseRequests",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 202, 89, 163, 186, 49, 25, 142, 249, 176, 200, 70, 25, 61, 162, 202, 161, 255, 3, 94, 73, 32, 161, 189, 153, 246, 144, 143, 164, 123, 36, 82, 107, 78, 222, 36, 95, 112, 21, 64, 110, 35, 84, 25, 185, 174, 202, 228, 179, 46, 132, 201, 226, 55, 215, 171, 144, 32, 155, 231, 35, 76, 242, 44, 234 }, new byte[] { 147, 66, 170, 39, 166, 210, 172, 85, 10, 50, 38, 108, 14, 235, 235, 28, 200, 38, 109, 201, 23, 102, 146, 112, 143, 181, 89, 65, 82, 24, 206, 232, 2, 189, 191, 114, 114, 215, 151, 139, 242, 203, 189, 39, 117, 239, 67, 208, 87, 224, 236, 205, 47, 195, 11, 243, 12, 177, 55, 241, 87, 26, 186, 40, 248, 203, 45, 244, 200, 129, 56, 231, 58, 114, 178, 4, 221, 189, 95, 91, 152, 102, 126, 79, 181, 38, 236, 168, 48, 87, 43, 89, 206, 250, 12, 175, 48, 119, 242, 88, 175, 139, 117, 244, 68, 15, 109, 246, 120, 129, 165, 154, 67, 132, 146, 188, 168, 8, 20, 200, 110, 162, 1, 101, 145, 26, 197, 252 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PurchaseRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PurchaseRequests");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PurchaseRequestRows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PurchaseRequestRows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 99, 174, 232, 226, 158, 226, 140, 67, 60, 93, 111, 31, 150, 176, 255, 219, 217, 12, 167, 197, 134, 1, 68, 171, 78, 21, 232, 46, 7, 238, 196, 67, 185, 132, 198, 126, 190, 16, 50, 25, 58, 52, 19, 240, 126, 136, 58, 87, 126, 62, 232, 48, 52, 71, 255, 73, 250, 96, 160, 88, 7, 53, 38, 246 }, new byte[] { 5, 141, 23, 31, 122, 191, 127, 194, 185, 0, 13, 40, 144, 29, 148, 121, 176, 183, 247, 65, 6, 53, 94, 56, 57, 79, 15, 165, 99, 191, 3, 144, 208, 28, 222, 209, 171, 105, 15, 211, 71, 173, 119, 242, 244, 103, 253, 248, 233, 107, 160, 50, 192, 161, 38, 172, 100, 191, 180, 244, 59, 13, 57, 35, 209, 129, 22, 217, 222, 63, 79, 155, 145, 160, 7, 36, 220, 5, 9, 99, 149, 87, 142, 201, 95, 174, 49, 58, 175, 195, 249, 103, 57, 190, 157, 190, 102, 228, 173, 185, 105, 132, 252, 22, 116, 89, 61, 98, 183, 208, 208, 123, 231, 128, 21, 41, 173, 249, 233, 195, 79, 137, 79, 111, 225, 57, 99, 231 } });
        }
    }
}
