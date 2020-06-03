using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStockInWhs",
                table: "PurchaseRequestRows");

            migrationBuilder.DropColumn(
                name: "InStockTotal",
                table: "PurchaseRequestRows");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 59, 161, 181, 103, 125, 58, 89, 161, 65, 117, 154, 90, 15, 87, 33, 94, 164, 156, 165, 147, 190, 23, 163, 124, 185, 122, 165, 93, 55, 164, 228, 234, 51, 144, 146, 10, 143, 147, 102, 158, 39, 128, 119, 131, 106, 217, 252, 27, 212, 171, 85, 204, 47, 239, 53, 217, 58, 213, 252, 171, 239, 191, 57, 56 }, new byte[] { 64, 202, 100, 40, 210, 234, 149, 243, 30, 240, 231, 224, 139, 135, 89, 106, 77, 168, 225, 164, 249, 21, 161, 139, 96, 145, 30, 65, 183, 206, 68, 104, 156, 90, 20, 126, 108, 118, 155, 194, 33, 43, 5, 244, 208, 163, 131, 70, 106, 131, 235, 202, 114, 30, 208, 145, 30, 237, 134, 171, 237, 235, 168, 178, 158, 91, 147, 62, 74, 163, 83, 50, 102, 34, 226, 206, 157, 148, 56, 60, 220, 206, 224, 59, 232, 71, 209, 59, 89, 225, 179, 153, 13, 106, 228, 36, 136, 85, 89, 106, 39, 5, 206, 129, 209, 75, 144, 209, 149, 219, 63, 35, 227, 54, 189, 41, 218, 187, 115, 93, 38, 90, 22, 232, 23, 200, 146, 76 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InStockInWhs",
                table: "PurchaseRequestRows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InStockTotal",
                table: "PurchaseRequestRows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 164, 121, 236, 228, 148, 225, 244, 218, 66, 181, 120, 129, 114, 241, 110, 130, 156, 56, 235, 75, 18, 64, 244, 48, 31, 29, 146, 10, 77, 21, 244, 100, 166, 117, 73, 208, 88, 155, 158, 127, 71, 134, 51, 52, 209, 100, 108, 21, 172, 0, 186, 246, 202, 88, 217, 226, 80, 73, 208, 15, 255, 54, 70, 44 }, new byte[] { 254, 239, 97, 135, 16, 44, 210, 99, 148, 163, 25, 178, 104, 23, 68, 66, 189, 242, 108, 141, 231, 56, 71, 89, 51, 61, 180, 71, 53, 153, 244, 80, 253, 223, 73, 112, 24, 53, 134, 23, 245, 121, 119, 27, 198, 96, 0, 243, 232, 161, 205, 187, 66, 173, 222, 86, 150, 139, 100, 190, 249, 167, 71, 182, 162, 227, 6, 186, 162, 92, 140, 249, 74, 17, 179, 13, 162, 192, 216, 230, 201, 233, 243, 100, 20, 253, 88, 207, 161, 208, 232, 184, 188, 162, 64, 82, 224, 6, 245, 210, 155, 133, 123, 93, 123, 39, 49, 65, 183, 89, 43, 153, 37, 221, 40, 246, 229, 54, 171, 159, 60, 23, 203, 232, 46, 11, 192, 173 } });
        }
    }
}
