using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjctType",
                table: "PurchaseRequests");

            migrationBuilder.AddColumn<int>(
                name: "ObjctTypeId",
                table: "PurchaseRequests",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 243, 152, 46, 48, 47, 61, 51, 133, 32, 112, 38, 227, 173, 4, 42, 94, 56, 112, 73, 235, 138, 223, 84, 106, 116, 247, 151, 9, 46, 250, 174, 156, 101, 70, 228, 95, 107, 165, 93, 105, 70, 161, 246, 10, 48, 139, 144, 95, 96, 44, 228, 43, 244, 246, 149, 128, 105, 133, 170, 157, 17, 17, 176, 167 }, new byte[] { 144, 19, 176, 116, 181, 111, 215, 88, 202, 187, 210, 77, 76, 41, 147, 156, 160, 234, 125, 212, 220, 179, 253, 205, 75, 32, 179, 14, 98, 81, 126, 36, 75, 177, 225, 247, 213, 80, 62, 67, 69, 104, 162, 93, 0, 69, 51, 5, 30, 80, 5, 237, 102, 251, 84, 69, 163, 147, 202, 190, 25, 106, 57, 186, 55, 56, 42, 209, 170, 45, 163, 13, 45, 162, 97, 82, 134, 202, 119, 224, 144, 219, 41, 135, 52, 57, 179, 183, 77, 196, 100, 38, 117, 124, 82, 177, 70, 253, 106, 142, 250, 85, 202, 235, 243, 102, 147, 151, 144, 52, 132, 242, 214, 82, 99, 174, 158, 35, 38, 92, 73, 103, 134, 187, 28, 149, 233, 44 } });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_ObjctTypeId",
                table: "PurchaseRequests",
                column: "ObjctTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_DocumentTypes_ObjctTypeId",
                table: "PurchaseRequests",
                column: "ObjctTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_DocumentTypes_ObjctTypeId",
                table: "PurchaseRequests");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequests_ObjctTypeId",
                table: "PurchaseRequests");

            migrationBuilder.DropColumn(
                name: "ObjctTypeId",
                table: "PurchaseRequests");

            migrationBuilder.AddColumn<string>(
                name: "ObjctType",
                table: "PurchaseRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 166, 142, 190, 52, 134, 0, 9, 164, 206, 29, 95, 207, 226, 188, 47, 81, 21, 171, 198, 128, 215, 71, 217, 98, 120, 65, 164, 191, 162, 74, 129, 134, 223, 5, 208, 158, 94, 12, 207, 40, 163, 42, 187, 5, 52, 252, 146, 13, 98, 251, 99, 45, 87, 161, 22, 187, 226, 110, 116, 166, 187, 86, 141, 35 }, new byte[] { 248, 231, 8, 229, 54, 140, 245, 222, 70, 177, 61, 251, 24, 172, 162, 251, 166, 147, 154, 234, 43, 64, 17, 148, 91, 242, 85, 14, 137, 89, 119, 184, 194, 34, 52, 17, 72, 2, 95, 15, 203, 112, 87, 130, 164, 115, 197, 166, 195, 160, 131, 75, 44, 156, 236, 204, 151, 95, 5, 143, 163, 112, 84, 182, 93, 129, 104, 240, 24, 249, 128, 14, 136, 140, 92, 242, 179, 37, 201, 227, 103, 20, 92, 14, 232, 133, 46, 95, 166, 154, 55, 109, 118, 32, 107, 33, 254, 224, 192, 49, 189, 107, 202, 167, 207, 84, 85, 33, 119, 103, 188, 220, 89, 139, 173, 199, 228, 3, 118, 78, 123, 134, 25, 95, 92, 102, 121, 181 } });
        }
    }
}
