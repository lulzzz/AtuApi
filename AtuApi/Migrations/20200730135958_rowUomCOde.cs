using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class rowUomCOde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UomCode",
                table: "PurchaseRequestRows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UomName",
                table: "PurchaseRequestRows",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 3, 179, 103, 246, 96, 214, 209, 226, 127, 114, 85, 0, 4, 233, 113, 255, 69, 6, 104, 44, 236, 14, 233, 167, 204, 133, 234, 132, 237, 103, 206, 19, 111, 49, 204, 148, 50, 95, 95, 147, 117, 169, 163, 248, 113, 206, 219, 20, 9, 81, 64, 136, 151, 193, 250, 25, 247, 28, 69, 213, 21, 209, 202 }, new byte[] { 139, 208, 65, 201, 117, 161, 186, 210, 167, 53, 53, 186, 81, 77, 133, 3, 61, 143, 153, 100, 137, 53, 193, 61, 36, 241, 217, 243, 236, 196, 21, 234, 132, 111, 33, 145, 0, 101, 63, 172, 100, 182, 217, 169, 32, 182, 167, 149, 212, 161, 153, 232, 82, 228, 121, 186, 84, 3, 202, 4, 213, 17, 206, 206, 241, 117, 128, 204, 21, 221, 104, 188, 30, 199, 193, 187, 37, 29, 136, 80, 93, 81, 163, 223, 81, 49, 113, 209, 142, 146, 83, 213, 28, 135, 53, 203, 142, 180, 230, 217, 73, 10, 26, 165, 209, 135, 39, 131, 81, 92, 239, 211, 87, 76, 180, 56, 180, 27, 141, 139, 218, 124, 111, 85, 19, 193, 25, 207 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UomCode",
                table: "PurchaseRequestRows");

            migrationBuilder.DropColumn(
                name: "UomName",
                table: "PurchaseRequestRows");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 51, 143, 48, 78, 108, 72, 226, 3, 24, 122, 99, 99, 214, 75, 108, 46, 77, 160, 65, 122, 189, 21, 5, 110, 210, 172, 102, 35, 107, 190, 124, 110, 180, 77, 228, 66, 148, 186, 230, 150, 43, 170, 123, 169, 206, 61, 179, 157, 97, 136, 116, 69, 3, 162, 186, 146, 58, 25, 114, 76, 70, 79, 96, 125 }, new byte[] { 79, 242, 214, 87, 128, 40, 136, 194, 82, 82, 181, 7, 229, 179, 200, 196, 67, 212, 62, 105, 86, 128, 21, 166, 118, 40, 209, 166, 32, 129, 207, 147, 231, 253, 141, 12, 145, 252, 83, 101, 45, 161, 229, 53, 35, 106, 104, 179, 147, 245, 67, 110, 213, 141, 77, 209, 158, 0, 111, 81, 24, 185, 195, 184, 120, 172, 203, 45, 209, 46, 47, 74, 163, 38, 247, 179, 111, 29, 68, 8, 9, 226, 86, 101, 207, 234, 242, 150, 116, 151, 212, 132, 1, 125, 243, 38, 3, 79, 0, 216, 132, 103, 116, 110, 211, 233, 149, 190, 232, 56, 35, 105, 0, 145, 193, 198, 132, 133, 209, 204, 114, 89, 112, 218, 39, 254, 230, 221 } });
        }
    }
}
