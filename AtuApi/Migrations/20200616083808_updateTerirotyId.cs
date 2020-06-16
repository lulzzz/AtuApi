using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class updateTerirotyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeritoryId",
                table: "PurchaseRequestRows",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 157, 176, 224, 111, 169, 136, 232, 28, 97, 167, 189, 171, 223, 160, 68, 87, 184, 73, 18, 35, 167, 28, 112, 100, 245, 54, 253, 254, 80, 13, 14, 230, 69, 137, 89, 203, 93, 169, 86, 101, 51, 163, 3, 50, 80, 218, 191, 77, 71, 189, 101, 202, 205, 235, 8, 199, 233, 170, 123, 180, 48, 253, 44, 169 }, new byte[] { 131, 67, 244, 169, 227, 199, 177, 58, 65, 108, 10, 5, 217, 184, 206, 21, 227, 18, 31, 180, 21, 75, 42, 162, 59, 117, 95, 212, 198, 165, 175, 166, 202, 176, 206, 140, 225, 146, 141, 10, 162, 73, 110, 199, 80, 41, 129, 217, 63, 87, 197, 125, 208, 181, 90, 119, 217, 103, 119, 136, 209, 63, 143, 51, 203, 201, 169, 152, 153, 93, 190, 196, 129, 13, 58, 109, 110, 151, 228, 90, 146, 84, 112, 120, 123, 241, 84, 179, 152, 216, 92, 48, 196, 175, 36, 152, 120, 110, 49, 208, 202, 228, 41, 184, 239, 249, 84, 33, 45, 26, 162, 175, 16, 106, 164, 133, 77, 67, 151, 216, 103, 76, 192, 159, 221, 30, 205, 122 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeritoryId",
                table: "PurchaseRequestRows",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 59, 161, 181, 103, 125, 58, 89, 161, 65, 117, 154, 90, 15, 87, 33, 94, 164, 156, 165, 147, 190, 23, 163, 124, 185, 122, 165, 93, 55, 164, 228, 234, 51, 144, 146, 10, 143, 147, 102, 158, 39, 128, 119, 131, 106, 217, 252, 27, 212, 171, 85, 204, 47, 239, 53, 217, 58, 213, 252, 171, 239, 191, 57, 56 }, new byte[] { 64, 202, 100, 40, 210, 234, 149, 243, 30, 240, 231, 224, 139, 135, 89, 106, 77, 168, 225, 164, 249, 21, 161, 139, 96, 145, 30, 65, 183, 206, 68, 104, 156, 90, 20, 126, 108, 118, 155, 194, 33, 43, 5, 244, 208, 163, 131, 70, 106, 131, 235, 202, 114, 30, 208, 145, 30, 237, 134, 171, 237, 235, 168, 178, 158, 91, 147, 62, 74, 163, 83, 50, 102, 34, 226, 206, 157, 148, 56, 60, 220, 206, 224, 59, 232, 71, 209, 59, 89, 225, 179, 153, 13, 106, 228, 36, 136, 85, 89, 106, 39, 5, 206, 129, 209, 75, 144, 209, 149, 219, 63, 35, 227, 54, 189, 41, 218, 187, 115, 93, 38, 90, 22, 232, 23, 200, 146, 76 } });
        }
    }
}
