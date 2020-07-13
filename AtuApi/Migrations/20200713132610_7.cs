﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "NotificationsHistory",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 99, 174, 232, 226, 158, 226, 140, 67, 60, 93, 111, 31, 150, 176, 255, 219, 217, 12, 167, 197, 134, 1, 68, 171, 78, 21, 232, 46, 7, 238, 196, 67, 185, 132, 198, 126, 190, 16, 50, 25, 58, 52, 19, 240, 126, 136, 58, 87, 126, 62, 232, 48, 52, 71, 255, 73, 250, 96, 160, 88, 7, 53, 38, 246 }, new byte[] { 5, 141, 23, 31, 122, 191, 127, 194, 185, 0, 13, 40, 144, 29, 148, 121, 176, 183, 247, 65, 6, 53, 94, 56, 57, 79, 15, 165, 99, 191, 3, 144, 208, 28, 222, 209, 171, 105, 15, 211, 71, 173, 119, 242, 244, 103, 253, 248, 233, 107, 160, 50, 192, 161, 38, 172, 100, 191, 180, 244, 59, 13, 57, 35, 209, 129, 22, 217, 222, 63, 79, 155, 145, 160, 7, 36, 220, 5, 9, 99, 149, 87, 142, 201, 95, 174, 49, 58, 175, 195, 249, 103, 57, 190, 157, 190, 102, 228, 173, 185, 105, 132, 252, 22, 116, 89, 61, 98, 183, 208, 208, 123, 231, 128, 21, 41, 173, 249, 233, 195, 79, 137, 79, 111, 225, 57, 99, 231 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "NotificationsHistory");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 92, 105, 220, 157, 197, 179, 179, 158, 71, 17, 73, 4, 250, 153, 253, 86, 244, 112, 67, 96, 185, 185, 214, 189, 110, 39, 115, 10, 234, 108, 232, 152, 61, 172, 58, 102, 246, 66, 252, 248, 162, 238, 34, 179, 80, 134, 50, 42, 134, 26, 107, 196, 170, 74, 49, 91, 110, 80, 220, 94, 90, 143, 193 }, new byte[] { 61, 15, 24, 31, 93, 98, 94, 181, 216, 227, 164, 27, 194, 130, 140, 212, 64, 98, 66, 194, 185, 125, 214, 51, 35, 35, 92, 23, 38, 252, 15, 12, 56, 26, 40, 224, 162, 235, 117, 96, 175, 226, 217, 192, 209, 172, 190, 195, 104, 30, 101, 115, 194, 2, 142, 59, 186, 116, 182, 208, 130, 245, 36, 39, 59, 168, 201, 210, 3, 150, 38, 44, 88, 157, 55, 219, 90, 65, 44, 116, 63, 93, 242, 139, 120, 188, 193, 20, 254, 7, 240, 24, 188, 113, 135, 172, 102, 19, 100, 216, 138, 125, 135, 151, 212, 164, 179, 16, 196, 34, 176, 114, 237, 178, 115, 84, 177, 225, 53, 34, 102, 186, 106, 92, 230, 168, 126, 167 } });
        }
    }
}
