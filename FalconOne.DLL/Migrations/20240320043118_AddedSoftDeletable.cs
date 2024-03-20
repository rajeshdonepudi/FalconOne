using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconOne.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDeletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCloned",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "AccountAlias",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240306051803942) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceAlias",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240306051803942) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCloned",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "AccountAlias",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240306051803942) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceAlias",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONVERT(NVARCHAR(max), 20240306051803942) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONVERT(NVARCHAR(max), 20240320043116925) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))");
        }
    }
}
