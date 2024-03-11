using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerceAPI.Migrations.LoggerContextMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scheme = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    HttpMethod = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Controller = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Path = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogResponses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scheme = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    HttpMethod = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Controller = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Path = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StatusCode = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogResponses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogRequests_Action",
                table: "LogRequests",
                column: "Action");

            migrationBuilder.CreateIndex(
                name: "IX_LogRequests_Controller",
                table: "LogRequests",
                column: "Controller");

            migrationBuilder.CreateIndex(
                name: "IX_LogResponses_Action",
                table: "LogResponses",
                column: "Action");

            migrationBuilder.CreateIndex(
                name: "IX_LogResponses_Controller",
                table: "LogResponses",
                column: "Controller");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogRequests");

            migrationBuilder.DropTable(
                name: "LogResponses");
        }
    }
}
