using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class updateUserPerms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermissionRoles",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 19, 1 },
                    { 18, 1 },
                    { 17, 1 },
                    { 16, 1 },
                    { 15, 1 },
                    { 14, 1 },
                    { 13, 1 },
                    { 12, 1 },
                    { 11, 1 },
                    { 10, 1 },
                    { 9, 1 },
                    { 8, 1 },
                    { 7, 1 },
                    { 6, 1 },
                    { 5, 1 },
                    { 20, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 243, 81, 221, 245, 169, 44, 168, 5, 254, 145, 9, 213, 51, 162, 74, 241, 105, 151, 249, 207, 87, 68, 140, 144, 123, 85, 196, 44, 24, 249, 204, 51, 222, 48, 67, 139, 243, 106, 61, 186, 100, 81, 171, 171, 10, 228, 159, 28, 182, 132, 69, 211, 10, 149, 7, 207, 33, 12, 226, 102, 41, 187, 71 }, new byte[] { 48, 72, 180, 92, 13, 233, 44, 61, 222, 209, 246, 123, 138, 186, 118, 117, 126, 144, 253, 244, 209, 188, 201, 23, 191, 45, 98, 78, 25, 200, 149, 240, 2, 221, 115, 187, 11, 137, 27, 169, 57, 185, 147, 153, 208, 97, 130, 185, 221, 110, 189, 25, 3, 173, 226, 23, 202, 139, 46, 253, 208, 49, 21, 148, 190, 179, 46, 251, 133, 200, 163, 171, 94, 215, 202, 156, 194, 184, 124, 138, 108, 40, 60, 197, 19, 189, 47, 196, 29, 85, 135, 73, 4, 30, 19, 202, 84, 214, 213, 12, 251, 90, 209, 190, 183, 1, 43, 6, 129, 80, 70, 217, 196, 94, 77, 147, 159, 159, 16, 35, 168, 167, 51, 103, 185, 221, 195, 152 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 112, 41, 116, 112, 49, 246, 37, 90, 213, 15, 248, 170, 196, 237, 189, 89, 81, 141, 157, 104, 88, 161, 249, 183, 4, 90, 214, 29, 106, 157, 111, 49, 18, 56, 100, 103, 37, 59, 128, 213, 240, 28, 130, 3, 78, 19, 181, 234, 28, 222, 240, 119, 93, 24, 69, 147, 52, 112, 222, 152, 177, 241, 14, 189 }, new byte[] { 183, 122, 121, 117, 67, 78, 98, 142, 165, 195, 85, 117, 157, 183, 55, 189, 93, 119, 220, 242, 139, 118, 36, 221, 14, 79, 8, 50, 45, 231, 201, 189, 99, 146, 158, 28, 33, 176, 187, 117, 156, 25, 209, 80, 179, 192, 2, 204, 133, 9, 201, 212, 55, 40, 249, 46, 54, 168, 124, 233, 192, 31, 130, 9, 201, 132, 197, 148, 112, 94, 148, 65, 141, 6, 139, 31, 177, 115, 78, 218, 240, 12, 91, 85, 240, 34, 198, 138, 69, 89, 205, 187, 169, 82, 159, 139, 228, 143, 134, 193, 146, 137, 28, 227, 126, 21, 119, 186, 221, 102, 57, 114, 104, 229, 50, 193, 9, 178, 252, 78, 120, 2, 198, 89, 160, 213, 158, 86 } });
        }
    }
}
