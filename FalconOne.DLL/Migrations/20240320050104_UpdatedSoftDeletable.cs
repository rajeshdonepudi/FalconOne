using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSoftDeletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TenantUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TenantUserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "AccountAlias",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240320050104133) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceAlias",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240320050104133) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TenantUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TenantUserRoles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "AccountAlias",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240320050104133) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceAlias",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240320050104133) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))");
        }
    }
}
