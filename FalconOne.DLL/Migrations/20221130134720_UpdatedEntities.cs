using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DLL.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationPolicyId",
                table: "UserClaims",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationPolicy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPolicy", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ApplicationPolicyId",
                table: "UserClaims",
                column: "ApplicationPolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_ApplicationPolicy_ApplicationPolicyId",
                table: "UserClaims",
                column: "ApplicationPolicyId",
                principalTable: "ApplicationPolicy",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_ApplicationPolicy_ApplicationPolicyId",
                table: "UserClaims");

            migrationBuilder.DropTable(
                name: "ApplicationPolicy");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_ApplicationPolicyId",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "ApplicationPolicyId",
                table: "UserClaims");
        }
    }
}
