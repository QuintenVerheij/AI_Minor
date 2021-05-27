using Microsoft.EntityFrameworkCore.Migrations;

namespace Fysio_API.Migrations
{
    public partial class Changestoexercisetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByTherapistId",
                table: "Exercises",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "PhotoLink",
                table: "Exercises",
                type: "text",
                nullable: true);

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
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PhotoLink",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByTherapistId",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatedByTherapistId",
                table: "Exercises",
                column: "CreatedByTherapistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
