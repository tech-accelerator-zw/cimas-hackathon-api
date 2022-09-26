using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CimasHackathon.API.Migrations
{
    public partial class MedicationDiseaseFixToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseId",
                table: "Medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_DiseaseId",
                table: "Medications",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Diseases_DiseaseId",
                table: "Medications",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Diseases_DiseaseId",
                table: "Medications");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Medications_DiseaseId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "Medications");
        }
    }
}
