using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Mini_Project_Recruitment_Agency_.Migrations
{
    /// <inheritdoc />
    public partial class validuser222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ValidUsers",
                table: "ValidUsers");

            migrationBuilder.RenameTable(
                name: "ValidUsers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ValidUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValidUsers",
                table: "ValidUsers",
                column: "Id");
        }
    }
}
