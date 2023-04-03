using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniproject.Migrations
{
    /// <inheritdoc />
    public partial class updatecourseResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseResults_trainees_traineeId",
                table: "courseResults");

            migrationBuilder.DropIndex(
                name: "IX_courseResults_traineeId",
                table: "courseResults");

            migrationBuilder.DropColumn(
                name: "traineeId",
                table: "courseResults");

            migrationBuilder.CreateIndex(
                name: "IX_courseResults_Trainee_Id",
                table: "courseResults",
                column: "Trainee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_courseResults_trainees_Trainee_Id",
                table: "courseResults",
                column: "Trainee_Id",
                principalTable: "trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseResults_trainees_Trainee_Id",
                table: "courseResults");

            migrationBuilder.DropIndex(
                name: "IX_courseResults_Trainee_Id",
                table: "courseResults");

            migrationBuilder.AddColumn<int>(
                name: "traineeId",
                table: "courseResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courseResults_traineeId",
                table: "courseResults",
                column: "traineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseResults_trainees_traineeId",
                table: "courseResults",
                column: "traineeId",
                principalTable: "trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
