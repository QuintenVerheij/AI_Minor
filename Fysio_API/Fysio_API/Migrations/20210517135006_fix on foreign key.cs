using Microsoft.EntityFrameworkCore.Migrations;

namespace Fysio_API.Migrations
{
    public partial class fixonforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientExercises_AspNetUsers_ClientId1",
                table: "ClientExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_ClientExercises_ClientId1",
                table: "ClientExercises");

            migrationBuilder.DropColumn(
                name: "CreatedByTherapist_Id",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "ClientExercises");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByTherapistId",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "ClientExercises",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_ClientExercises_ClientId",
                table: "ClientExercises",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientExercises_AspNetUsers_ClientId",
                table: "ClientExercises",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises",
                column: "CreatedByTherapistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientExercises_AspNetUsers_ClientId",
                table: "ClientExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_ClientExercises_ClientId",
                table: "ClientExercises");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByTherapistId",
                table: "Exercises",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByTherapist_Id",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ClientExercises",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "ClientExercises",
                type: "text",
                nullable: true);

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
    }
}
