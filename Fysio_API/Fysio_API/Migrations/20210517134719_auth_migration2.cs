using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fysio_API.Migrations
{
    public partial class auth_migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientExercises_User_ClientId",
                table: "ClientExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_User_CreatedByTherapistUserId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CreatedByTherapistUserId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_ClientExercises_ClientId",
                table: "ClientExercises");

            migrationBuilder.DropColumn(
                name: "CreatedByTherapistUserId",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByTherapistId",
                table: "Exercises",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "ClientExercises",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatedByTherapistId",
                table: "Exercises",
                column: "CreatedByTherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientExercises_ClientId1",
                table: "ClientExercises",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientExercises_AspNetUsers_ClientId1",
                table: "ClientExercises",
                column: "ClientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises",
                column: "CreatedByTherapistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientExercises_AspNetUsers_ClientId1",
                table: "ClientExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CreatedByTherapistId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_ClientExercises_ClientId1",
                table: "ClientExercises");

            migrationBuilder.DropColumn(
                name: "CreatedByTherapistId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "ClientExercises");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByTherapistUserId",
                table: "Exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatedByTherapistUserId",
                table: "Exercises",
                column: "CreatedByTherapistUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientExercises_ClientId",
                table: "ClientExercises",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientExercises_User_ClientId",
                table: "ClientExercises",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_User_CreatedByTherapistUserId",
                table: "Exercises",
                column: "CreatedByTherapistUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
