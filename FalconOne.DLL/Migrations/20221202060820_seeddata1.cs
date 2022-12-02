using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DLL.Migrations
{
    public partial class seeddata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bedfca7-9ee1-4096-a29f-0b804cecfdd0");

            migrationBuilder.DeleteData(
                table: "Navigation",
                keyColumn: "Id",
                keyValue: new Guid("2e1f4005-7c97-4bba-99bd-4e46a8dd9b2b"));

            migrationBuilder.DeleteData(
                table: "Navigation",
                keyColumn: "Id",
                keyValue: new Guid("4260de73-5a64-4799-a6e4-aa0f93bfee65"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "88ee42f4-7508-428f-9687-b4392ac6618c", 0, "6d21179e-1dc0-4e79-83a9-39eda2b8cdef", "rajesh.dnp01@gmail.com", true, "Rajesh", "Donepudi", false, null, null, null, "AQAAAAEAACcQAAAAEB9pQSSJODwK37JModPay/apjS02usEPb8i6LDUOqdmd7EnK9hIT0Dj0LM36goxomA==", "8886014996", false, "5f0882d8-ba01-4f03-b794-1b2b4ece4d1b", false, "rajesh.dnp01" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("303a4b9f-a426-4885-9ec4-f237a795f3ad"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User login", "Login", "login" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("6455f8f2-92b8-4449-9cf8-cc3b5257fbb1"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User signup", "Singup", "signup" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88ee42f4-7508-428f-9687-b4392ac6618c");

            migrationBuilder.DeleteData(
                table: "Navigation",
                keyColumn: "Id",
                keyValue: new Guid("303a4b9f-a426-4885-9ec4-f237a795f3ad"));

            migrationBuilder.DeleteData(
                table: "Navigation",
                keyColumn: "Id",
                keyValue: new Guid("6455f8f2-92b8-4449-9cf8-cc3b5257fbb1"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bedfca7-9ee1-4096-a29f-0b804cecfdd0", 0, "50b2f171-9f84-4034-9dee-3f2d7ed09d2d", "rajesh.dnp01@gmail.com", true, "Rajesh", "Donepudi", false, null, null, null, "APmjA+4E8IEIpgaWV7BE3IK/XluflLqAi3BgObZX3fz/spKMENKFexlF+UDHTsUK1Q==", "8886014996", false, "e1022387-af28-49e1-acd0-4848e0899de7", false, "rajesh.dnp01" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("2e1f4005-7c97-4bba-99bd-4e46a8dd9b2b"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User login", "Login", "login" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("4260de73-5a64-4799-a6e4-aa0f93bfee65"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User signup", "Singup", "signup" });
        }
    }
}
