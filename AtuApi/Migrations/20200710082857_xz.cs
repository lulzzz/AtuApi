using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WareHouse",
                table: "PurchaseRequestRows");

            migrationBuilder.AddColumn<string>(
                name: "WareHouseCode",
                table: "PurchaseRequestRows",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 220, 233, 96, 51, 14, 22, 207, 87, 178, 201, 115, 102, 227, 69, 76, 43, 174, 241, 72, 166, 153, 38, 107, 129, 4, 137, 203, 130, 239, 82, 210, 192, 55, 57, 29, 59, 111, 38, 221, 66, 204, 149, 132, 7, 223, 119, 187, 148, 159, 36, 49, 171, 189, 88, 168, 66, 58, 246, 55, 122, 209, 118, 74, 179 }, new byte[] { 71, 80, 7, 86, 131, 156, 163, 243, 246, 104, 243, 80, 184, 59, 146, 233, 251, 35, 208, 129, 103, 222, 13, 90, 244, 134, 163, 72, 38, 136, 202, 4, 45, 238, 3, 240, 182, 109, 209, 79, 9, 180, 36, 209, 187, 85, 114, 55, 195, 161, 208, 23, 117, 154, 55, 163, 103, 102, 73, 187, 113, 6, 177, 162, 60, 69, 228, 59, 203, 189, 231, 225, 88, 106, 25, 146, 132, 28, 107, 52, 176, 69, 147, 180, 199, 193, 167, 139, 35, 46, 120, 55, 254, 10, 25, 51, 53, 213, 94, 30, 39, 231, 92, 4, 224, 52, 154, 222, 170, 35, 37, 207, 15, 78, 131, 34, 68, 187, 94, 165, 117, 172, 161, 182, 2, 73, 159, 43 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WareHouseCode",
                table: "PurchaseRequestRows");

            migrationBuilder.AddColumn<string>(
                name: "WareHouse",
                table: "PurchaseRequestRows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 222, 135, 73, 4, 131, 25, 181, 28, 208, 54, 69, 217, 38, 101, 29, 111, 148, 131, 36, 213, 170, 4, 200, 169, 229, 156, 154, 69, 3, 174, 56, 5, 20, 143, 67, 181, 138, 91, 234, 247, 232, 178, 137, 188, 68, 18, 224, 132, 244, 215, 81, 173, 219, 237, 1, 2, 161, 86, 49, 130, 100, 41, 116 }, new byte[] { 149, 234, 75, 43, 254, 255, 69, 89, 7, 82, 26, 15, 136, 213, 113, 171, 47, 7, 227, 2, 252, 165, 133, 89, 146, 91, 146, 95, 59, 88, 166, 3, 72, 195, 67, 156, 50, 229, 199, 145, 72, 26, 246, 13, 38, 240, 66, 159, 237, 95, 93, 6, 123, 49, 174, 115, 55, 244, 198, 30, 35, 128, 35, 106, 130, 254, 29, 46, 36, 238, 136, 104, 11, 157, 58, 189, 219, 94, 13, 11, 29, 56, 97, 117, 201, 227, 236, 88, 39, 6, 61, 119, 117, 14, 82, 140, 181, 108, 175, 142, 91, 148, 11, 95, 152, 157, 31, 92, 123, 180, 86, 243, 128, 18, 15, 226, 91, 162, 184, 94, 71, 42, 97, 26, 142, 144, 88, 102 } });
        }
    }
}
