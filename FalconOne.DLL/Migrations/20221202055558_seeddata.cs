using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DLL.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dc6ed9b-ec2e-43e4-90a1-fd68f97ab65f");

            migrationBuilder.InsertData(
                table: "ApplicationPolicies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9fa14d9e-0d8e-4b51-85e4-c4bdd5873d14"), "user-policy" });

            migrationBuilder.InsertData(
                table: "ApplicationPolicies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b7538a53-d3b2-4b66-ba40-97619cda8d00"), "admin-policy" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bedfca7-9ee1-4096-a29f-0b804cecfdd0", 0, "50b2f171-9f84-4034-9dee-3f2d7ed09d2d", "rajesh.dnp01@gmail.com", true, "Rajesh", "Donepudi", false, null, null, null, "APmjA+4E8IEIpgaWV7BE3IK/XluflLqAi3BgObZX3fz/spKMENKFexlF+UDHTsUK1Q==", "8886014996", false, "e1022387-af28-49e1-acd0-4848e0899de7", false, "rajesh.dnp01" });

            migrationBuilder.InsertData(
                table: "ApplicationClaims",
                columns: new[] { "Id", "ApplicationPolicyId", "Name", "Type", "Values" },
                values: new object[] { new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), new Guid("9fa14d9e-0d8e-4b51-85e4-c4bdd5873d14"), "user-claim", "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor", "can-login,can-signup,can-reset-password,can-create-account" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("2e1f4005-7c97-4bba-99bd-4e46a8dd9b2b"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User login", "Login", "login" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("4260de73-5a64-4799-a6e4-aa0f93bfee65"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User signup", "Singup", "signup" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationPolicies",
                keyColumn: "Id",
                keyValue: new Guid("b7538a53-d3b2-4b66-ba40-97619cda8d00"));

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

            migrationBuilder.DeleteData(
                table: "ApplicationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"));

            migrationBuilder.DeleteData(
                table: "ApplicationPolicies",
                keyColumn: "Id",
                keyValue: new Guid("9fa14d9e-0d8e-4b51-85e4-c4bdd5873d14"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9dc6ed9b-ec2e-43e4-90a1-fd68f97ab65f", 0, "6f4c3b4e-5ac7-4b87-b756-11dfd9199e4b", "rajesh.dnp01@gmail.com", true, "Rajesh", "Donepudi", false, null, null, null, "APmjA+4E8IEIpgaWV7BE3IK/XluflLqAi3BgObZX3fz/spKMENKFexlF+UDHTsUK1Q==", "8886014996", false, "9724a6fe-664d-49f8-9d11-6c414273bfea", false, "rajesh.dnp01" });
        }
    }
}
