using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologiesOnPlatformNET.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCloudReadyToAspNetCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrontendFramework",
                table: "AspNetCores");

            migrationBuilder.DropColumn(
                name: "IsCloudReady",
                table: "AspNetCores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FrontendFramework",
                table: "AspNetCores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCloudReady",
                table: "AspNetCores",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
