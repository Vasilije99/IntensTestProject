using Microsoft.EntityFrameworkCore.Migrations;

namespace IntensTestProject.Migrations
{
    public partial class ManyToManyConfigure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Candidates_JobCandidateId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_JobCandidateId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "JobCandidateId",
                table: "Skills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobCandidateId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobCandidateId",
                table: "Skills",
                column: "JobCandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Candidates_JobCandidateId",
                table: "Skills",
                column: "JobCandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
