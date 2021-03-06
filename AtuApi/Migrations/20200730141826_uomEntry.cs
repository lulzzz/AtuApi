﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class uomEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UomEntry",
                table: "PurchaseRequestRows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 48, 216, 85, 55, 100, 101, 80, 169, 83, 254, 196, 165, 175, 151, 51, 60, 134, 116, 73, 200, 75, 79, 69, 103, 149, 182, 247, 234, 237, 143, 255, 188, 55, 91, 159, 137, 220, 96, 64, 2, 198, 226, 251, 23, 120, 22, 53, 2, 135, 16, 175, 73, 202, 215, 204, 43, 101, 211, 74, 205, 166, 66, 250, 59 }, new byte[] { 123, 94, 226, 124, 227, 179, 63, 16, 149, 183, 203, 40, 141, 18, 71, 252, 100, 251, 0, 241, 151, 119, 179, 53, 200, 33, 31, 144, 99, 247, 161, 169, 37, 77, 223, 32, 103, 9, 203, 42, 146, 127, 175, 253, 187, 140, 13, 8, 58, 151, 62, 196, 62, 50, 242, 187, 210, 27, 207, 221, 151, 10, 251, 67, 104, 82, 154, 109, 208, 25, 197, 166, 188, 57, 142, 89, 84, 234, 56, 231, 23, 222, 146, 101, 36, 216, 189, 197, 241, 68, 60, 234, 149, 163, 215, 133, 65, 27, 180, 250, 29, 42, 178, 72, 163, 75, 160, 44, 32, 31, 14, 217, 210, 182, 126, 71, 6, 214, 108, 152, 183, 0, 128, 47, 43, 219, 102, 236 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UomEntry",
                table: "PurchaseRequestRows");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 3, 179, 103, 246, 96, 214, 209, 226, 127, 114, 85, 0, 4, 233, 113, 255, 69, 6, 104, 44, 236, 14, 233, 167, 204, 133, 234, 132, 237, 103, 206, 19, 111, 49, 204, 148, 50, 95, 95, 147, 117, 169, 163, 248, 113, 206, 219, 20, 9, 81, 64, 136, 151, 193, 250, 25, 247, 28, 69, 213, 21, 209, 202 }, new byte[] { 139, 208, 65, 201, 117, 161, 186, 210, 167, 53, 53, 186, 81, 77, 133, 3, 61, 143, 153, 100, 137, 53, 193, 61, 36, 241, 217, 243, 236, 196, 21, 234, 132, 111, 33, 145, 0, 101, 63, 172, 100, 182, 217, 169, 32, 182, 167, 149, 212, 161, 153, 232, 82, 228, 121, 186, 84, 3, 202, 4, 213, 17, 206, 206, 241, 117, 128, 204, 21, 221, 104, 188, 30, 199, 193, 187, 37, 29, 136, 80, 93, 81, 163, 223, 81, 49, 113, 209, 142, 146, 83, 213, 28, 135, 53, 203, 142, 180, 230, 217, 73, 10, 26, 165, 209, 135, 39, 131, 81, 92, 239, 211, 87, 76, 180, 56, 180, 27, 141, 139, 218, 124, 111, 85, 19, 193, 25, 207 } });
        }
    }
}
