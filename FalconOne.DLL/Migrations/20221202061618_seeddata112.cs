using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DLL.Migrations
{
    public partial class seeddata112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "9a44830f-d5ce-4271-b398-1f8df4991979", 0, "cd3b83eb-1539-4bca-b104-aeecb1ed2558", "rajesh.dnp01@gmail.com", true, "Rajesh", "Donepudi", false, null, "rajesh.dnp01@gmail.com", "rajesh.dnp01", "AQAAAAEAACcQAAAAENz77V15NMn+bGr/IexL7NCJ64PwftsSUPA4FdpTpHDgajIKcc9TdGe4X6B81zC3QA==", "8886014996", false, "f4895549-a0fb-4b40-a72b-41e383a757e1", false, "rajesh.dnp01" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("b0c91f26-2b0d-4e70-ac61-58c8f71d2c81"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User signup", "Singup", "signup" });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "Description", "Name", "URL" },
                values: new object[] { new Guid("b8eb47be-3a07-4a13-ad9c-bdefbad17d33"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), "User login", "Login", "login" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a44830f-d5ce-4271-b398-1f8df4991979");

            migrationBuilder.DeleteData(
                table: "Navigation",
                keyColumn: "Id",
                keyValue: new Guid("b0c91f26-2b0d-4e70-ac61-58c8f71d2c81"));

            migrationBuilder.DeleteData(
                table: "Navigation",
                keyColumn: "Id",
                keyValue: new Guid("b8eb47be-3a07-4a13-ad9c-bdefbad17d33"));

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
    }
}
