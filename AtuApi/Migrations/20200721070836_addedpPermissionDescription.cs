﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class addedpPermissionDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermissionDescription",
                table: "Permissions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 169, 177, 237, 213, 200, 224, 126, 164, 237, 230, 248, 24, 13, 225, 14, 25, 129, 165, 108, 143, 200, 6, 18, 166, 190, 193, 239, 224, 21, 110, 159, 23, 228, 65, 250, 189, 25, 212, 71, 103, 15, 37, 169, 70, 128, 163, 191, 5, 163, 248, 193, 6, 136, 252, 59, 209, 100, 6, 246, 42, 238, 130, 81 }, new byte[] { 41, 233, 143, 108, 251, 199, 241, 139, 123, 207, 148, 118, 213, 51, 218, 44, 62, 81, 34, 41, 137, 176, 41, 234, 12, 143, 142, 29, 247, 30, 92, 122, 245, 97, 20, 86, 84, 249, 34, 98, 242, 229, 113, 36, 33, 216, 123, 243, 73, 27, 116, 94, 76, 148, 138, 223, 253, 52, 43, 223, 120, 56, 19, 37, 153, 72, 240, 100, 87, 204, 120, 81, 246, 92, 73, 2, 3, 32, 190, 18, 254, 2, 21, 31, 128, 254, 19, 4, 34, 14, 36, 140, 13, 124, 220, 112, 74, 122, 234, 142, 12, 37, 231, 246, 89, 22, 131, 117, 227, 251, 92, 199, 28, 201, 37, 143, 223, 18, 95, 110, 123, 154, 226, 16, 250, 54, 17, 44 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionDescription",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 193, 65, 15, 16, 254, 192, 7, 246, 158, 238, 100, 248, 95, 95, 158, 21, 0, 225, 198, 140, 134, 165, 87, 154, 185, 99, 224, 227, 196, 252, 225, 29, 247, 246, 247, 38, 141, 167, 96, 48, 247, 211, 156, 241, 16, 198, 18, 49, 182, 112, 163, 127, 194, 118, 104, 251, 144, 167, 67, 19, 241, 21, 168, 228 }, new byte[] { 208, 248, 0, 189, 19, 87, 163, 76, 13, 23, 28, 246, 181, 26, 3, 162, 253, 80, 147, 203, 195, 110, 249, 32, 251, 93, 93, 97, 171, 188, 35, 206, 212, 111, 28, 242, 211, 202, 196, 66, 72, 14, 134, 249, 98, 86, 164, 214, 6, 16, 143, 103, 159, 50, 109, 166, 4, 71, 250, 2, 104, 175, 201, 129, 196, 172, 229, 197, 24, 240, 101, 8, 116, 163, 114, 32, 5, 152, 236, 134, 43, 147, 135, 48, 236, 134, 73, 62, 200, 124, 34, 1, 73, 54, 254, 121, 255, 158, 162, 68, 183, 186, 208, 77, 131, 227, 58, 68, 2, 57, 240, 133, 22, 145, 192, 208, 240, 231, 92, 214, 57, 103, 179, 157, 208, 213, 24, 111 } });
        }
    }
}
