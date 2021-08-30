using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SRA_HopsitalWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Admin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoofDependent = table.Column<int>(type: "int", nullable: false),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 9, 141, 114, 238, 5, 18, 44, 34, 191, 55, 143, 228, 151, 26, 176, 108, 226, 117, 6, 47, 215, 97, 37, 3, 204, 209, 129, 80, 91, 113, 78, 40, 41, 43, 230, 199, 63, 78, 103, 62, 214, 44, 162, 19, 63, 201, 43, 107, 139, 217, 60, 171, 92, 106, 11, 69, 44, 113, 49, 85, 92, 74, 65, 226 }, new byte[] { 39, 40, 82, 52, 46, 72, 188, 90, 218, 139, 174, 205, 29, 74, 102, 181, 203, 216, 27, 155, 127, 193, 170, 210, 171, 173, 83, 180, 244, 231, 27, 23, 36, 109, 140, 231, 71, 174, 250, 137, 157, 158, 161, 54, 112, 153, 12, 68, 66, 23, 133, 166, 70, 33, 115, 213, 27, 151, 170, 241, 63, 35, 179, 124, 94, 62, 152, 178, 19, 160, 252, 50, 86, 162, 202, 92, 37, 173, 128, 52, 225, 100, 204, 238, 32, 10, 28, 55, 172, 145, 169, 115, 192, 199, 169, 24, 223, 178, 243, 9, 159, 68, 163, 192, 228, 61, 41, 150, 197, 185, 121, 103, 147, 145, 88, 224, 167, 136, 144, 134, 217, 71, 111, 129, 213, 136, 12, 40 }, "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, new byte[] { 9, 141, 114, 238, 5, 18, 44, 34, 191, 55, 143, 228, 151, 26, 176, 108, 226, 117, 6, 47, 215, 97, 37, 3, 204, 209, 129, 80, 91, 113, 78, 40, 41, 43, 230, 199, 63, 78, 103, 62, 214, 44, 162, 19, 63, 201, 43, 107, 139, 217, 60, 171, 92, 106, 11, 69, 44, 113, 49, 85, 92, 74, 65, 226 }, new byte[] { 39, 40, 82, 52, 46, 72, 188, 90, 218, 139, 174, 205, 29, 74, 102, 181, 203, 216, 27, 155, 127, 193, 170, 210, 171, 173, 83, 180, 244, 231, 27, 23, 36, 109, 140, 231, 71, 174, 250, 137, 157, 158, 161, 54, 112, 153, 12, 68, 66, 23, 133, 166, 70, 33, 115, 213, 27, 151, 170, 241, 63, 35, 179, 124, 94, 62, 152, 178, 19, 160, 252, 50, 86, 162, 202, 92, 37, 173, 128, 52, 225, 100, 204, 238, 32, 10, 28, 55, 172, 145, 169, 115, 192, 199, 169, 24, 223, 178, 243, 9, 159, 68, 163, 192, 228, 61, 41, 150, 197, 185, 121, 103, 147, 145, 88, 224, 167, 136, 144, 134, 217, 71, 111, 129, 213, 136, 12, 40 }, "User2" });

            migrationBuilder.InsertData(
                table: "Registers",
                columns: new[] { "Id", "AvailableDate", "IdentityNo", "Name", "NoofDependent", "UserId" },
                values: new object[] { 1, new DateTime(2021, 8, 30, 23, 25, 17, 571, DateTimeKind.Local).AddTicks(7099), "Test56", "TestUser1", 2, 1 });

            migrationBuilder.InsertData(
                table: "Registers",
                columns: new[] { "Id", "AvailableDate", "IdentityNo", "Name", "NoofDependent", "UserId" },
                values: new object[] { 2, new DateTime(2021, 8, 30, 23, 25, 17, 571, DateTimeKind.Local).AddTicks(7802), "BODPR56", "TestUser2", 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_UserId",
                table: "Registers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
