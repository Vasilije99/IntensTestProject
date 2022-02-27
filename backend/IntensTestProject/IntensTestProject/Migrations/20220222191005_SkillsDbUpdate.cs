using Microsoft.EntityFrameworkCore.Migrations;

namespace IntensTestProject.Migrations
{
    public partial class SkillsDbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Candidates_JobCandidateId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "JobCandidateId",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Candidates_JobCandidateId",
                table: "Skills",
                column: "JobCandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Candidates_JobCandidateId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "JobCandidateId",
                table: "Skills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Candidates_JobCandidateId",
                table: "Skills",
                column: "JobCandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
