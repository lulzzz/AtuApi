﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xztest5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "NotificationsHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 65, 226, 199, 167, 242, 69, 129, 127, 181, 56, 57, 125, 134, 58, 54, 202, 150, 26, 173, 173, 166, 59, 229, 58, 99, 131, 54, 237, 65, 107, 5, 226, 142, 127, 224, 138, 13, 248, 157, 98, 81, 255, 168, 47, 206, 87, 89, 237, 86, 200, 94, 147, 30, 23, 253, 243, 39, 33, 55, 172, 244, 94, 48, 142 }, new byte[] { 8, 217, 221, 69, 209, 124, 156, 149, 156, 101, 163, 34, 149, 84, 75, 180, 139, 198, 146, 28, 209, 225, 187, 4, 43, 31, 15, 250, 169, 7, 210, 239, 19, 104, 232, 199, 18, 232, 196, 16, 207, 0, 52, 94, 99, 243, 79, 25, 162, 235, 40, 31, 165, 249, 149, 74, 115, 109, 112, 49, 21, 233, 85, 121, 146, 196, 187, 9, 189, 186, 64, 89, 195, 89, 87, 35, 182, 87, 138, 73, 104, 27, 37, 238, 252, 254, 249, 232, 45, 216, 64, 22, 191, 215, 9, 234, 138, 245, 168, 9, 201, 28, 88, 10, 81, 43, 165, 108, 90, 186, 123, 214, 11, 133, 52, 11, 198, 151, 213, 184, 253, 52, 162, 91, 130, 145, 101, 244 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "NotificationsHistory");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 239, 239, 127, 179, 183, 252, 237, 11, 48, 76, 31, 152, 97, 154, 32, 248, 67, 2, 108, 133, 78, 106, 87, 53, 189, 153, 221, 65, 21, 206, 159, 237, 153, 119, 102, 200, 22, 64, 26, 56, 63, 95, 232, 21, 151, 3, 218, 89, 172, 24, 248, 180, 102, 219, 243, 164, 81, 30, 147, 174, 145, 239, 239 }, new byte[] { 230, 144, 155, 197, 213, 70, 68, 29, 167, 254, 88, 218, 124, 86, 164, 27, 163, 213, 72, 182, 227, 78, 223, 159, 196, 114, 190, 48, 9, 44, 241, 105, 29, 36, 70, 140, 150, 132, 241, 101, 72, 127, 34, 196, 219, 54, 246, 79, 68, 78, 245, 179, 59, 115, 180, 89, 195, 224, 213, 69, 85, 167, 254, 52, 161, 65, 103, 33, 89, 70, 124, 148, 118, 159, 176, 210, 49, 223, 59, 201, 26, 7, 10, 114, 191, 27, 217, 160, 135, 230, 59, 128, 4, 199, 31, 4, 126, 70, 231, 168, 85, 59, 143, 207, 98, 222, 127, 187, 113, 76, 224, 139, 156, 157, 139, 144, 211, 7, 177, 9, 73, 131, 54, 176, 231, 109, 93, 93 } });
        }
    }
}
