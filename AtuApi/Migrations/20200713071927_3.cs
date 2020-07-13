using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_DocumentTypes_ObjctTypeId",
                table: "PurchaseRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ObjctTypeId",
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
                values: new object[] { new byte[] { 173, 78, 51, 13, 14, 76, 28, 242, 56, 20, 18, 164, 40, 242, 13, 233, 114, 176, 65, 247, 98, 22, 65, 25, 101, 49, 189, 187, 225, 111, 108, 26, 229, 148, 2, 6, 78, 33, 93, 142, 208, 206, 88, 188, 24, 34, 179, 61, 55, 233, 8, 250, 250, 148, 137, 236, 195, 131, 25, 78, 160, 103, 37, 111 }, new byte[] { 159, 107, 12, 51, 57, 58, 132, 250, 209, 251, 85, 83, 153, 247, 142, 103, 17, 32, 227, 94, 246, 118, 65, 112, 121, 219, 221, 91, 190, 127, 27, 243, 138, 175, 243, 116, 157, 26, 84, 19, 112, 170, 245, 77, 76, 83, 104, 213, 171, 228, 36, 201, 162, 207, 244, 164, 42, 207, 31, 196, 9, 4, 164, 33, 195, 169, 8, 29, 8, 239, 175, 17, 85, 180, 31, 49, 167, 155, 196, 166, 109, 85, 173, 251, 217, 223, 61, 164, 33, 98, 56, 191, 120, 180, 171, 61, 20, 209, 129, 82, 165, 140, 37, 0, 1, 56, 248, 138, 152, 206, 64, 188, 248, 226, 78, 123, 61, 213, 227, 193, 0, 195, 156, 86, 180, 229, 36, 5 } });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_DocumentTypes_ObjctTypeId",
                table: "PurchaseRequests",
                column: "ObjctTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_DocumentTypes_ObjctTypeId",
                table: "PurchaseRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ObjctTypeId",
                table: "PurchaseRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 243, 152, 46, 48, 47, 61, 51, 133, 32, 112, 38, 227, 173, 4, 42, 94, 56, 112, 73, 235, 138, 223, 84, 106, 116, 247, 151, 9, 46, 250, 174, 156, 101, 70, 228, 95, 107, 165, 93, 105, 70, 161, 246, 10, 48, 139, 144, 95, 96, 44, 228, 43, 244, 246, 149, 128, 105, 133, 170, 157, 17, 17, 176, 167 }, new byte[] { 144, 19, 176, 116, 181, 111, 215, 88, 202, 187, 210, 77, 76, 41, 147, 156, 160, 234, 125, 212, 220, 179, 253, 205, 75, 32, 179, 14, 98, 81, 126, 36, 75, 177, 225, 247, 213, 80, 62, 67, 69, 104, 162, 93, 0, 69, 51, 5, 30, 80, 5, 237, 102, 251, 84, 69, 163, 147, 202, 190, 25, 106, 57, 186, 55, 56, 42, 209, 170, 45, 163, 13, 45, 162, 97, 82, 134, 202, 119, 224, 144, 219, 41, 135, 52, 57, 179, 183, 77, 196, 100, 38, 117, 124, 82, 177, 70, 253, 106, 142, 250, 85, 202, 235, 243, 102, 147, 151, 144, 52, 132, 242, 214, 82, 99, 174, 158, 35, 38, 92, 73, 103, 134, 187, 28, 149, 233, 44 } });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_DocumentTypes_ObjctTypeId",
                table: "PurchaseRequests",
                column: "ObjctTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
