﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeritoryId",
                table: "PurchaseRequestRows",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 164, 121, 236, 228, 148, 225, 244, 218, 66, 181, 120, 129, 114, 241, 110, 130, 156, 56, 235, 75, 18, 64, 244, 48, 31, 29, 146, 10, 77, 21, 244, 100, 166, 117, 73, 208, 88, 155, 158, 127, 71, 134, 51, 52, 209, 100, 108, 21, 172, 0, 186, 246, 202, 88, 217, 226, 80, 73, 208, 15, 255, 54, 70, 44 }, new byte[] { 254, 239, 97, 135, 16, 44, 210, 99, 148, 163, 25, 178, 104, 23, 68, 66, 189, 242, 108, 141, 231, 56, 71, 89, 51, 61, 180, 71, 53, 153, 244, 80, 253, 223, 73, 112, 24, 53, 134, 23, 245, 121, 119, 27, 198, 96, 0, 243, 232, 161, 205, 187, 66, 173, 222, 86, 150, 139, 100, 190, 249, 167, 71, 182, 162, 227, 6, 186, 162, 92, 140, 249, 74, 17, 179, 13, 162, 192, 216, 230, 201, 233, 243, 100, 20, 253, 88, 207, 161, 208, 232, 184, 188, 162, 64, 82, 224, 6, 245, 210, 155, 133, 123, 93, 123, 39, 49, 65, 183, 89, 43, 153, 37, 221, 40, 246, 229, 54, 171, 159, 60, 23, 203, 232, 46, 11, 192, 173 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeritoryId",
                table: "PurchaseRequestRows");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 17, 150, 225, 41, 101, 232, 5, 176, 203, 147, 214, 40, 160, 128, 213, 139, 97, 224, 37, 216, 192, 24, 25, 2, 208, 79, 175, 242, 0, 233, 165, 144, 103, 30, 99, 49, 109, 146, 241, 146, 25, 199, 84, 101, 47, 246, 130, 91, 212, 166, 168, 213, 149, 173, 114, 197, 214, 101, 209, 193, 39, 211, 41 }, new byte[] { 221, 66, 60, 177, 168, 23, 200, 239, 124, 97, 233, 46, 86, 240, 23, 109, 160, 54, 38, 145, 117, 220, 129, 243, 186, 37, 233, 205, 111, 219, 179, 213, 255, 148, 118, 105, 91, 60, 24, 152, 19, 127, 77, 247, 24, 185, 82, 20, 73, 84, 242, 218, 152, 202, 129, 219, 166, 183, 195, 37, 108, 86, 149, 251, 53, 211, 142, 253, 105, 248, 92, 18, 161, 27, 73, 127, 249, 157, 165, 90, 72, 142, 227, 69, 129, 21, 6, 142, 130, 201, 140, 74, 8, 18, 143, 146, 124, 230, 86, 100, 127, 225, 160, 12, 16, 52, 75, 229, 15, 41, 185, 121, 97, 167, 233, 15, 252, 246, 90, 201, 147, 21, 89, 151, 181, 193, 216, 134 } });
        }
    }
}