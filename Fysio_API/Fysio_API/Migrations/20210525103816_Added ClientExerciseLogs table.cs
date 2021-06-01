using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fysio_API.Migrations
{
    public partial class AddedClientExerciseLogstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientExerciseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientExerciseId = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientExerciseLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientExerciseLogs_ClientExercises_ClientExerciseId",
                        column: x => x.ClientExerciseId,
                        principalTable: "ClientExercises",
                        principalColumn: "ClientExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientExerciseLogs_ClientExerciseId",
                table: "ClientExerciseLogs",
                column: "ClientExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientExerciseLogs");
        }
    }
}
