using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtuApi.Migrations
{
    public partial class xztest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RejectResons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocId = table.Column<int>(nullable: false),
                    RejectReason = table.Column<string>(nullable: true),
                    RejectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectResons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RejectResons_Users_RejectorId",
                        column: x => x.RejectorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 177, 192, 72, 87, 30, 71, 82, 32, 142, 140, 242, 119, 7, 2, 122, 253, 189, 133, 22, 249, 99, 35, 86, 65, 84, 233, 202, 123, 181, 212, 48, 81, 3, 172, 185, 110, 70, 202, 50, 227, 50, 232, 4, 141, 145, 143, 52, 31, 34, 183, 31, 130, 135, 132, 3, 143, 138, 182, 163, 56, 143, 63, 46, 249 }, new byte[] { 107, 136, 212, 239, 103, 8, 121, 43, 56, 108, 14, 168, 53, 64, 175, 69, 132, 245, 46, 169, 215, 135, 199, 45, 177, 188, 228, 212, 178, 202, 188, 137, 245, 24, 220, 53, 19, 191, 107, 244, 208, 104, 145, 137, 113, 208, 145, 17, 145, 137, 89, 114, 197, 183, 137, 50, 145, 59, 95, 188, 58, 49, 172, 181, 56, 152, 79, 26, 212, 103, 87, 202, 234, 193, 166, 28, 136, 84, 135, 221, 105, 24, 128, 98, 165, 191, 178, 96, 30, 22, 29, 137, 118, 187, 83, 40, 151, 130, 145, 152, 69, 225, 87, 250, 110, 1, 58, 99, 8, 147, 120, 63, 236, 83, 163, 100, 10, 94, 161, 220, 250, 142, 13, 121, 201, 14, 5, 0 } });

            migrationBuilder.CreateIndex(
                name: "IX_RejectResons_RejectorId",
                table: "RejectResons",
                column: "RejectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejectResons");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 169, 177, 237, 213, 200, 224, 126, 164, 237, 230, 248, 24, 13, 225, 14, 25, 129, 165, 108, 143, 200, 6, 18, 166, 190, 193, 239, 224, 21, 110, 159, 23, 228, 65, 250, 189, 25, 212, 71, 103, 15, 37, 169, 70, 128, 163, 191, 5, 163, 248, 193, 6, 136, 252, 59, 209, 100, 6, 246, 42, 238, 130, 81 }, new byte[] { 41, 233, 143, 108, 251, 199, 241, 139, 123, 207, 148, 118, 213, 51, 218, 44, 62, 81, 34, 41, 137, 176, 41, 234, 12, 143, 142, 29, 247, 30, 92, 122, 245, 97, 20, 86, 84, 249, 34, 98, 242, 229, 113, 36, 33, 216, 123, 243, 73, 27, 116, 94, 76, 148, 138, 223, 253, 52, 43, 223, 120, 56, 19, 37, 153, 72, 240, 100, 87, 204, 120, 81, 246, 92, 73, 2, 3, 32, 190, 18, 254, 2, 21, 31, 128, 254, 19, 4, 34, 14, 36, 140, 13, 124, 220, 112, 74, 122, 234, 142, 12, 37, 231, 246, 89, 22, 131, 117, 227, 251, 92, 199, 28, 201, 37, 143, 223, 18, 95, 110, 123, 154, 226, 16, 250, 54, 17, 44 } });
        }
    }
}
