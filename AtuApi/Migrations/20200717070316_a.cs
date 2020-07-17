using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PurchaseRequests");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PurchaseRequestRows",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 227, 94, 231, 179, 115, 154, 194, 216, 211, 44, 208, 158, 69, 219, 189, 220, 245, 14, 201, 189, 10, 210, 156, 196, 98, 0, 145, 161, 56, 129, 80, 233, 108, 147, 172, 127, 50, 160, 95, 83, 93, 238, 8, 69, 255, 74, 42, 171, 98, 99, 85, 40, 134, 167, 109, 176, 127, 68, 174, 198, 116, 6, 81, 99 }, new byte[] { 187, 7, 111, 18, 31, 96, 246, 130, 91, 43, 126, 7, 135, 61, 112, 237, 22, 123, 226, 184, 110, 241, 174, 161, 197, 214, 14, 81, 221, 52, 91, 77, 49, 121, 39, 15, 235, 163, 117, 18, 214, 250, 185, 110, 207, 234, 181, 29, 158, 154, 141, 235, 224, 35, 171, 202, 87, 78, 46, 201, 212, 141, 150, 37, 101, 6, 195, 159, 236, 203, 224, 232, 210, 141, 90, 245, 39, 161, 42, 77, 27, 113, 94, 143, 162, 33, 151, 121, 79, 81, 36, 232, 124, 150, 94, 165, 197, 209, 71, 126, 35, 233, 74, 1, 116, 141, 60, 36, 236, 185, 43, 117, 69, 169, 23, 52, 250, 40, 176, 78, 24, 113, 240, 120, 105, 5, 3, 183 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PurchaseRequestRows");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PurchaseRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 202, 89, 163, 186, 49, 25, 142, 249, 176, 200, 70, 25, 61, 162, 202, 161, 255, 3, 94, 73, 32, 161, 189, 153, 246, 144, 143, 164, 123, 36, 82, 107, 78, 222, 36, 95, 112, 21, 64, 110, 35, 84, 25, 185, 174, 202, 228, 179, 46, 132, 201, 226, 55, 215, 171, 144, 32, 155, 231, 35, 76, 242, 44, 234 }, new byte[] { 147, 66, 170, 39, 166, 210, 172, 85, 10, 50, 38, 108, 14, 235, 235, 28, 200, 38, 109, 201, 23, 102, 146, 112, 143, 181, 89, 65, 82, 24, 206, 232, 2, 189, 191, 114, 114, 215, 151, 139, 242, 203, 189, 39, 117, 239, 67, 208, 87, 224, 236, 205, 47, 195, 11, 243, 12, 177, 55, 241, 87, 26, 186, 40, 248, 203, 45, 244, 200, 129, 56, 231, 58, 114, 178, 4, 221, 189, 95, 91, 152, 102, 126, 79, 181, 38, 236, 168, 48, 87, 43, 89, 206, 250, 12, 175, 48, 119, 242, 88, 175, 139, 117, 244, 68, 15, 109, 246, 120, 129, 165, 154, 67, 132, 146, 188, 168, 8, 20, 200, 110, 162, 1, 101, 145, 26, 197, 252 } });
        }
    }
}
