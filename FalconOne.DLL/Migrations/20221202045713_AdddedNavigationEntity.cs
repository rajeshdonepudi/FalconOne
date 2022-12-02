using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DLL.Migrations
{
    public partial class AdddedNavigationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClaimId",
                table: "ApplicationClaims",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "ApplicationClaims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Navigation_ApplicationClaims_ApplicationClaimId",
                        column: x => x.ApplicationClaimId,
                        principalTable: "ApplicationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Navigation_ApplicationClaimId",
                table: "Navigation",
                column: "ApplicationClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Navigation");

            migrationBuilder.DropColumn(
                name: "Values",
                table: "ApplicationClaims");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationClaims",
                newName: "ClaimId");
        }
    }
}
