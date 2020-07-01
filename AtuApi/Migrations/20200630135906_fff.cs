using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class fff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermissionRoles",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 112, 41, 116, 112, 49, 246, 37, 90, 213, 15, 248, 170, 196, 237, 189, 89, 81, 141, 157, 104, 88, 161, 249, 183, 4, 90, 214, 29, 106, 157, 111, 49, 18, 56, 100, 103, 37, 59, 128, 213, 240, 28, 130, 3, 78, 19, 181, 234, 28, 222, 240, 119, 93, 24, 69, 147, 52, 112, 222, 152, 177, 241, 14, 189 }, new byte[] { 183, 122, 121, 117, 67, 78, 98, 142, 165, 195, 85, 117, 157, 183, 55, 189, 93, 119, 220, 242, 139, 118, 36, 221, 14, 79, 8, 50, 45, 231, 201, 189, 99, 146, 158, 28, 33, 176, 187, 117, 156, 25, 209, 80, 179, 192, 2, 204, 133, 9, 201, 212, 55, 40, 249, 46, 54, 168, 124, 233, 192, 31, 130, 9, 201, 132, 197, 148, 112, 94, 148, 65, 141, 6, 139, 31, 177, 115, 78, 218, 240, 12, 91, 85, 240, 34, 198, 138, 69, 89, 205, 187, 169, 82, 159, 139, 228, 143, 134, 193, 146, 137, 28, 227, 126, 21, 119, 186, 221, 102, 57, 114, 104, 229, 50, 193, 9, 178, 252, 78, 120, 2, 198, 89, 160, 213, 158, 86 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 179, 162, 91, 102, 119, 11, 187, 60, 18, 169, 214, 253, 53, 52, 245, 123, 86, 30, 242, 152, 186, 171, 6, 149, 248, 21, 193, 80, 238, 1, 164, 52, 120, 181, 235, 123, 36, 163, 81, 231, 150, 55, 30, 236, 177, 226, 242, 53, 12, 195, 14, 83, 242, 195, 211, 136, 16, 7, 125, 207, 241, 221, 25, 65 }, new byte[] { 48, 133, 112, 4, 74, 6, 177, 89, 241, 108, 75, 161, 140, 113, 54, 248, 245, 248, 94, 28, 104, 15, 148, 73, 9, 96, 52, 23, 77, 53, 147, 135, 161, 137, 180, 249, 238, 21, 174, 135, 44, 172, 218, 1, 84, 95, 236, 25, 117, 55, 174, 46, 20, 137, 139, 176, 161, 20, 100, 69, 117, 55, 45, 78, 53, 175, 17, 126, 40, 110, 78, 34, 32, 148, 211, 94, 195, 92, 89, 75, 230, 44, 8, 214, 5, 69, 217, 27, 131, 21, 129, 23, 101, 135, 27, 96, 50, 216, 222, 5, 19, 81, 27, 2, 245, 115, 193, 214, 105, 20, 84, 113, 66, 38, 226, 93, 124, 122, 136, 70, 38, 0, 199, 33, 69, 178, 112, 216 } });
        }
    }
}
