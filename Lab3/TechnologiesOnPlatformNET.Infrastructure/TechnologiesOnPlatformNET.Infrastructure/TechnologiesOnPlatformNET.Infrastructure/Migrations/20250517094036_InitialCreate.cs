using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologiesOnPlatformNET.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DotNetTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DotNetTechnologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FrontendFramework = table.Column<string>(type: "TEXT", nullable: false),
                    IsCloudReady = table.Column<bool>(type: "INTEGER", nullable: false),
                    DotNetTechnologyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebTechnologies_DotNetTechnologies_DotNetTechnologyId",
                        column: x => x.DotNetTechnologyId,
                        principalTable: "DotNetTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetCores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SupportsMinimalAPI = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    FrontendFramework = table.Column<string>(type: "TEXT", nullable: false),
                    IsCloudReady = table.Column<bool>(type: "INTEGER", nullable: false),
                    WebTechnologyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetCores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetCores_WebTechnologies_WebTechnologyId",
                        column: x => x.WebTechnologyId,
                        principalTable: "WebTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetCores_WebTechnologyId",
                table: "AspNetCores",
                column: "WebTechnologyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebTechnologies_DotNetTechnologyId",
                table: "WebTechnologies",
                column: "DotNetTechnologyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetCores");

            migrationBuilder.DropTable(
                name: "WebTechnologies");

            migrationBuilder.DropTable(
                name: "DotNetTechnologies");
        }
    }
}
