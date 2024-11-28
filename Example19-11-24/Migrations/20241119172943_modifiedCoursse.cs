using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example19_11_24.Migrations
{
    /// <inheritdoc />
    public partial class modifiedCoursse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_FacultyMembers_FacultyId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_FacultyMembers_FacultyId",
                table: "Courses",
                column: "FacultyId",
                principalTable: "FacultyMembers",
                principalColumn: "FacultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_FacultyMembers_FacultyId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_FacultyMembers_FacultyId",
                table: "Courses",
                column: "FacultyId",
                principalTable: "FacultyMembers",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
