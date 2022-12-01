using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DLL.Migrations
{
    public partial class UpdatedEntities1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_ApplicationPolicy_ApplicationPolicyId",
                table: "UserClaims");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestInformation",
                table: "RequestInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationPolicy",
                table: "ApplicationPolicy");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "ApplicationClaims");

            migrationBuilder.RenameTable(
                name: "RequestInformation",
                newName: "RequestInformations");

            migrationBuilder.RenameTable(
                name: "ApplicationPolicy",
                newName: "ApplicationPolicies");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_ApplicationPolicyId",
                table: "ApplicationClaims",
                newName: "IX_ApplicationClaims_ApplicationPolicyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationClaims",
                table: "ApplicationClaims",
                column: "ClaimId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestInformations",
                table: "RequestInformations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationPolicies",
                table: "ApplicationPolicies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationClaims_ApplicationPolicies_ApplicationPolicyId",
                table: "ApplicationClaims",
                column: "ApplicationPolicyId",
                principalTable: "ApplicationPolicies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationClaims_ApplicationPolicies_ApplicationPolicyId",
                table: "ApplicationClaims");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestInformations",
                table: "RequestInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationPolicies",
                table: "ApplicationPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationClaims",
                table: "ApplicationClaims");

            migrationBuilder.RenameTable(
                name: "RequestInformations",
                newName: "RequestInformation");

            migrationBuilder.RenameTable(
                name: "ApplicationPolicies",
                newName: "ApplicationPolicy");

            migrationBuilder.RenameTable(
                name: "ApplicationClaims",
                newName: "UserClaims");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationClaims_ApplicationPolicyId",
                table: "UserClaims",
                newName: "IX_UserClaims_ApplicationPolicyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestInformation",
                table: "RequestInformation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationPolicy",
                table: "ApplicationPolicy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "ClaimId");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_ApplicationPolicy_ApplicationPolicyId",
                table: "UserClaims",
                column: "ApplicationPolicyId",
                principalTable: "ApplicationPolicy",
                principalColumn: "Id");
        }
    }
}
