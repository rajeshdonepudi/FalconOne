using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DLL.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ClaimId",
                table: "Navigation",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9dc6ed9b-ec2e-43e4-90a1-fd68f97ab65f", 0, "6f4c3b4e-5ac7-4b87-b756-11dfd9199e4b", "rajesh.dnp01@gmail.com", true, "Rajesh", "Donepudi", false, null, null, null, "APmjA+4E8IEIpgaWV7BE3IK/XluflLqAi3BgObZX3fz/spKMENKFexlF+UDHTsUK1Q==", "8886014996", false, "9724a6fe-664d-49f8-9d11-6c414273bfea", false, "rajesh.dnp01" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dc6ed9b-ec2e-43e4-90a1-fd68f97ab65f");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimId",
                table: "Navigation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
