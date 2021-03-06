﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserLevel",
                table: "ApprovalsEmployees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 226, 39, 143, 94, 121, 238, 55, 161, 88, 89, 22, 102, 99, 31, 200, 198, 144, 126, 183, 74, 226, 35, 242, 248, 122, 77, 88, 82, 98, 146, 29, 242, 121, 125, 50, 93, 145, 245, 156, 32, 29, 14, 39, 12, 234, 127, 214, 86, 106, 156, 249, 65, 201, 48, 152, 4, 143, 43, 158, 55, 228, 83, 165 }, new byte[] { 96, 205, 246, 49, 60, 203, 187, 92, 87, 252, 43, 255, 85, 204, 27, 7, 254, 241, 109, 172, 153, 39, 127, 111, 140, 123, 220, 149, 47, 152, 236, 241, 221, 250, 45, 88, 48, 174, 173, 214, 40, 216, 117, 150, 30, 157, 16, 237, 200, 127, 181, 224, 84, 218, 85, 170, 53, 112, 37, 138, 19, 26, 236, 190, 45, 98, 39, 100, 39, 117, 220, 124, 205, 140, 51, 147, 131, 50, 220, 237, 78, 90, 32, 6, 145, 56, 35, 198, 16, 175, 206, 62, 41, 56, 211, 99, 218, 32, 114, 68, 100, 142, 155, 26, 113, 213, 23, 26, 117, 116, 84, 6, 19, 185, 42, 184, 162, 227, 210, 16, 188, 40, 220, 73, 124, 77, 225, 107 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLevel",
                table: "ApprovalsEmployees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 78, 51, 13, 14, 76, 28, 242, 56, 20, 18, 164, 40, 242, 13, 233, 114, 176, 65, 247, 98, 22, 65, 25, 101, 49, 189, 187, 225, 111, 108, 26, 229, 148, 2, 6, 78, 33, 93, 142, 208, 206, 88, 188, 24, 34, 179, 61, 55, 233, 8, 250, 250, 148, 137, 236, 195, 131, 25, 78, 160, 103, 37, 111 }, new byte[] { 159, 107, 12, 51, 57, 58, 132, 250, 209, 251, 85, 83, 153, 247, 142, 103, 17, 32, 227, 94, 246, 118, 65, 112, 121, 219, 221, 91, 190, 127, 27, 243, 138, 175, 243, 116, 157, 26, 84, 19, 112, 170, 245, 77, 76, 83, 104, 213, 171, 228, 36, 201, 162, 207, 244, 164, 42, 207, 31, 196, 9, 4, 164, 33, 195, 169, 8, 29, 8, 239, 175, 17, 85, 180, 31, 49, 167, 155, 196, 166, 109, 85, 173, 251, 217, 223, 61, 164, 33, 98, 56, 191, 120, 180, 171, 61, 20, 209, 129, 82, 165, 140, 37, 0, 1, 56, 248, 138, 152, 206, 64, 188, 248, 226, 78, 123, 61, 213, 227, 193, 0, 195, 156, 86, 180, 229, 36, 5 } });
        }
    }
}
