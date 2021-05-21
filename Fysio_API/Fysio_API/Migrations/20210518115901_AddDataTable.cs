using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fysio_API.Migrations
{
    public partial class AddDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    DataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pose = table.Column<string>(type: "text", nullable: true),
                    Target = table.Column<bool>(type: "boolean", nullable: false),
                    NoseX = table.Column<int>(type: "integer", nullable: true),
                    NoseY = table.Column<int>(type: "integer", nullable: true),
                    LeftEyeX = table.Column<int>(type: "integer", nullable: true),
                    LeftEyeY = table.Column<int>(type: "integer", nullable: true),
                    RightEyeX = table.Column<int>(type: "integer", nullable: true),
                    RightEyeY = table.Column<int>(type: "integer", nullable: true),
                    LeftEarX = table.Column<int>(type: "integer", nullable: true),
                    LeftEarY = table.Column<int>(type: "integer", nullable: true),
                    LeftShoulderX = table.Column<int>(type: "integer", nullable: true),
                    LeftShoulderY = table.Column<int>(type: "integer", nullable: true),
                    RightShoulderX = table.Column<int>(type: "integer", nullable: true),
                    RightShoulderY = table.Column<int>(type: "integer", nullable: true),
                    LeftElbowX = table.Column<int>(type: "integer", nullable: true),
                    LeftElbowY = table.Column<int>(type: "integer", nullable: true),
                    RightElbowX = table.Column<int>(type: "integer", nullable: true),
                    RightElbowY = table.Column<int>(type: "integer", nullable: true),
                    LeftWristX = table.Column<int>(type: "integer", nullable: true),
                    LeftWristY = table.Column<int>(type: "integer", nullable: true),
                    RightWristX = table.Column<int>(type: "integer", nullable: true),
                    RightWristY = table.Column<int>(type: "integer", nullable: true),
                    LeftHipX = table.Column<int>(type: "integer", nullable: true),
                    LeftHipY = table.Column<int>(type: "integer", nullable: true),
                    RightHipX = table.Column<int>(type: "integer", nullable: true),
                    RightHipY = table.Column<int>(type: "integer", nullable: true),
                    LeftKneeX = table.Column<int>(type: "integer", nullable: true),
                    LeftKneeY = table.Column<int>(type: "integer", nullable: true),
                    RightKneeX = table.Column<int>(type: "integer", nullable: true),
                    RightKneeY = table.Column<int>(type: "integer", nullable: true),
                    LeftAnkleX = table.Column<int>(type: "integer", nullable: true),
                    LeftAnkleY = table.Column<int>(type: "integer", nullable: true),
                    RightAnkleX = table.Column<int>(type: "integer", nullable: true),
                    RightAnkleY = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.DataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datas");
        }
    }
}
