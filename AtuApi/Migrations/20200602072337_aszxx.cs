using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class aszxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeCode",
                table: "PurchaseRequests");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PurchaseRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 92, 221, 23, 212, 53, 135, 198, 28, 76, 113, 182, 121, 82, 190, 7, 12, 38, 234, 42, 169, 199, 206, 137, 145, 61, 113, 204, 187, 173, 144, 71, 44, 238, 173, 138, 113, 10, 187, 175, 233, 94, 19, 210, 198, 135, 64, 138, 60, 218, 205, 56, 255, 252, 148, 140, 32, 206, 29, 120, 208, 89, 65, 251, 19 }, new byte[] { 21, 57, 156, 129, 35, 182, 147, 195, 163, 194, 178, 166, 194, 78, 218, 42, 170, 54, 228, 90, 49, 197, 154, 112, 58, 36, 173, 209, 216, 186, 92, 253, 38, 180, 29, 183, 235, 149, 138, 165, 163, 219, 178, 140, 99, 74, 19, 114, 18, 207, 124, 28, 179, 122, 65, 186, 192, 243, 219, 65, 90, 23, 109, 247, 71, 16, 59, 173, 147, 164, 177, 169, 194, 109, 143, 110, 206, 24, 78, 131, 216, 49, 42, 142, 229, 204, 203, 49, 226, 36, 225, 193, 75, 181, 26, 127, 50, 172, 36, 151, 66, 182, 201, 230, 175, 35, 227, 200, 46, 180, 144, 32, 141, 114, 25, 58, 11, 222, 224, 246, 50, 42, 206, 125, 230, 252, 210, 224 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PurchaseRequests");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeCode",
                table: "PurchaseRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 247, 42, 194, 192, 235, 224, 27, 251, 181, 134, 152, 15, 58, 60, 171, 136, 92, 171, 52, 137, 72, 244, 83, 188, 116, 214, 89, 104, 8, 168, 48, 5, 103, 150, 20, 102, 179, 143, 224, 31, 114, 151, 89, 35, 75, 76, 173, 210, 132, 173, 255, 147, 40, 245, 108, 137, 120, 62, 28, 68, 251, 47, 225, 68 }, new byte[] { 211, 165, 182, 6, 198, 109, 64, 200, 89, 84, 87, 140, 1, 108, 11, 244, 11, 67, 241, 129, 158, 29, 195, 217, 242, 137, 246, 104, 255, 228, 79, 46, 196, 30, 61, 160, 71, 18, 9, 90, 248, 88, 252, 128, 240, 158, 75, 132, 105, 46, 15, 212, 233, 44, 82, 53, 157, 55, 0, 89, 190, 97, 144, 41, 163, 23, 145, 222, 28, 213, 167, 216, 37, 60, 127, 87, 86, 189, 54, 195, 69, 53, 193, 195, 62, 109, 87, 91, 138, 95, 50, 111, 17, 122, 113, 71, 161, 138, 82, 94, 99, 213, 99, 159, 255, 16, 221, 109, 46, 254, 205, 44, 19, 179, 177, 244, 48, 191, 243, 47, 162, 41, 210, 225, 17, 25, 234, 91 } });
        }
    }
}
